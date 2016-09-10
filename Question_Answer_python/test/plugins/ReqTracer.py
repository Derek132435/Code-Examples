"""
Derek Edwards
Writes requirements and their corresponding tests to project_traces.txt
"""
from nose2.events import Plugin


class ReqTracer(Plugin):
    """
    ReqTracer class plugin writes requirements and their corresponding tests to project_traces.txt
    """

    def __init__(self):
        self.config_section = 'Req-Tracer'
        self.command_line_switch = (None, 'Req-Tracer', 'Req-Tracer Enabled')

    def after_summary_report(self):
        """
        Writes requirements and their corresponding tests to project_traces.txt
        :return: void, write to project_traces.txt
        """
        output_file = open("Project_Traces.txt", "w")
        for key, item in sorted(REQUIREMENTS.items()):
            output_file.write(key + ' ')
            output_file.write(item.req_text)
            for func in item.func_name:
                output_file.write(' ' + func + ',')
                output_file.write('\n')
            output_file.write('\n')
        for job in STORIES:
            output_file.write(job.JS_text + '\n')
            for index in job.JS_trace:
                output_file.write(' ' + index + ',')
                output_file.write('\n')


class RequirementTrace(object):
    """
    Traces requirements tests for plugin
    """
    req_text = ""

    def __init__(self, text):
        self.req_text = text
        self.func_name = []

REQUIREMENTS = {}


def requirements(req_list):
    """
    Create a dictionary of requirements
    :param req_list: list to edit
    :return: requirements dictionary
    """
    def wrapper(func):
        """
        Wrapper function for requirements
        :param func: function for requirements
        :return: void
        """
        def add_req_and_call(*args, **kwargs):
            """
            Add requirements to dictionary
            :param args: wrapper args
            :param kwargs: wrapper kargs
            :return: requirements
            """
            for req in req_list:
                if req not in REQUIREMENTS.keys():
                    raise Exception('Requirement {0} not defined'.format(req))
                REQUIREMENTS[req].func_name.append(func.__name__)
            return func(*args, **kwargs)

        return add_req_and_call

    return wrapper


class JSTrace(object):
    """
    Traces Job Story based tests for plugin
    """
    job_story_text = ""

    def __init__(self, text):
        self.job_story_text = text
        self.job_story_trace = []

STORIES = []


def story(job_list):
    """
    Create a list of job stories
    :param job_list: list to edit
    :return: Job story list
    """
    def wrapper(func):
        """
        Wrapper function for job stories
        :param func: function for job story
        :return: void
        """
        def add_story_and_call(*args, **kwargs):
            """
            Add Job Story to list
            :param args: wrapper args
            :param kwargs: wrapper kargs
            :return: job story
            """
            called_story = False
            for job in STORIES:
                if job.job_story_text == job_list:
                    job.job_story_trace.append(func.__name__)
                    called_story = True
                    break
            if called_story is False:
                raise Exception('Story {0} not defined'.format(job_list))
            return func(*args, **kwargs)

        return add_story_and_call

    return wrapper

with open('Project_Requirements.txt') as f:
    for line in f.readlines():
        if '#0' in line:
            req_id, desc = line.split(' ', 1)
            REQUIREMENTS[req_id] = RequirementTrace(desc)
        elif line[0] == '*':
            job_id = line[1:].strip()
            STORIES.append(JSTrace(job_id))
