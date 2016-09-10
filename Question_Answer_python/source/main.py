"""
Derek Edwards
Main Interface class
"""
import difflib
from source.question_answer import QA
from source.shape_checker import get_triangle_type, get_quadrilateral_type
from source.answer import convert_units
from source.git_utils import is_file_in_repo, get_git_file_info, get_file_info,\
    get_repo_branch, get_repo_url, get_repo_root

NOT_A_QUESTION_RETURN = "Was that a question?"
UNKNOWN_QUESTION = "I don't know, please provide the answer"
NO_QUESTION = 'Please ask a question first'
NO_TEACH = 'I don\'t know about that. I was taught differently'


class Interface(object):
    """
    Interface class for asking and answering questions.
    Has functionality to add new questions and answers as well as correct answers
    """
    def __init__(self):

        self.keywords = ['How', 'What', 'Where', 'Who', "Why", "Will", "Is"]
        self.question_mark = chr(0x3F)
        self.last_question = None

        self.question_answers = {
            'What type of triangle is ': QA('What type of triangle is ', get_triangle_type),
            'What type of quadrilateral is ':
                QA('What type of quadrilateral is ', get_quadrilateral_type),
            'Is the in the repo': QA('Is the in the repo', is_file_in_repo),
            'What is the status of <file>': QA('What is the status of', get_git_file_info),
            'What is the deal with <file>': QA('What is the deal with', get_file_info),
            'What branch is <file>': QA('What branch is', get_repo_branch),
            'Where did <file> come from': QA('Where did come from', get_repo_url),
            'What is root of <file path>?': QA('What is root of ', get_repo_root)
        }

        self.metric = {'millimeters': .001, 'centimeters': .01, 'decimeters': .1,
                       'meters': 1, 'dekameters': 10, 'hectometers': 100, 'kilometers': 1000}

    def ask(self, question=""):
        """
        Primary ask function.
        Determine validity of question asked and availability of answer.
        Accept and answer questions via the question_answers dictionary.
        Print all questions and answers to log_file.
        :param question: Question to be answered and logged
        :return: Answer to the question
        """
        output_file = open("log_file.txt", "a")
        output_file.write(str(question) + ': ')
        if not isinstance(question, str):
            self.last_question = None
            output_file = open("log_file.txt", "a")
            output_file.write('Exception: Not a String' + '\n')
            raise Exception('Not A String!')
        if question[:8] == 'Convert ':
            q_args = question.split(' ')
            if len(q_args) == 5:
                convert = convert_units(float(q_args[1]), (q_args[2]), (q_args[4]))
                output_file = open("log_file.txt", "a")
                output_file.write(convert + '\n')
                return convert
        if question[-1] != self.question_mark or question.split(' ')[0] not in self.keywords:
            self.last_question = None
            output_file = open("log_file.txt", "a")
            output_file.write('no answer' + '\n')
            return NOT_A_QUESTION_RETURN
        else:
            parsed_question = ""
            args = []
            for keyword in question[:-1].split(' '):
                try:
                    if keyword[0] == '<' and keyword[-1] == '>':
                        filename = keyword[1:len(keyword)-1]
                        args.append(filename)
                    else:
                        args.append(float(keyword))
                except:
                    parsed_question += "{0} ".format(keyword)
            parsed_question = parsed_question[0:-1]
            self.last_question = parsed_question
            for answer in self.question_answers.values():
                if difflib.SequenceMatcher(a=answer.question, b=parsed_question).ratio() >= .90:
                    if answer.function is None:
                        temp = answer.value
                        string = str(temp)
                        output_file = open("log_file.txt", "a")
                        output_file.write(string + '\n')
                        return temp
                    else:
                        try:
                            temp = answer.function(*args)
                            string = str(temp)
                            output_file = open("log_file.txt", "a")
                            output_file.write(string + '\n')
                            return temp
                        except Exception as ex:
                            raise ex
            else:
                output_file = open("log_file.txt", "a")
                output_file.write('Unknown question' + '\n')
                return UNKNOWN_QUESTION

    def teach(self, answer=""):
        """
        Add a new question and answer to the question_answer dictionary.
        :param answer: New answer to add
        :return: void unless bad answer is given
        """
        if self.last_question is None:
            return NO_QUESTION
        elif self.last_question in self.question_answers.keys():
            return NO_TEACH
        else:
            self.__add_answer(answer)

    def correct(self, answer=""):
        """
        Correct an answer in the question_answer dictionary.
        :param answer: answer to correct
        :return: void unless no question
        """
        if self.last_question is None:
            return NO_QUESTION
        else:
            self.__add_answer(answer)

    def __add_answer(self, answer):
        """
        Add a new answer to the question_answer dictionary
        :param answer: New answer to add
        :return: void
        """
        self.question_answers[self.last_question] = QA(self.last_question, answer)
