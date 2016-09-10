"""
Derek Edwards
Mock tests for source.git_utils
"""
import os
from unittest import TestCase
from mock import mock
from test.plugins.ReqTracer import requirements
from source.main import Interface
from source.git_utils import is_file_in_repo, get_git_file_info, has_untracked_files,\
    is_repo_dirty, has_diff_files


class MockTest(TestCase):
    """
    git_utils function test class
    """

    @requirements(["#0100"])
    @mock.patch('source.git_utils.get_diff_files')
    @mock.patch('source.git_utils.get_untracked_files')
    @mock.patch('source.git_utils.git_execute')
    def test_mock_special_no(self, mock_diff_files, mock_git_execute, mock_get_untracked_files):
        """
        test mock is_file_in_repo for untracked no
        :param mock_diff_files: mock of function diff_files
        :param mock_git_execute: sub process git_execute
        :param mock_get_untracked_files: mock of function get_untracked_files
        :return: assertion: untracked no
        """
        blah = 'requirements.txt'
        mock_git_execute.return_value = ''
        mock_get_untracked_files.return_value = [os.path.abspath(blah)]
        mock_diff_files.return_value = [os.path.abspath(blah)]
        print mock_diff_files.return_value
        result = is_file_in_repo(blah)
        self.assertEqual(result, 'No')

    @requirements(['#0101'])
    @mock.patch('subprocess.Popen')
    def test_mock_path_exception(self, mock_subproc_popen):
        """
        Test mock function path checker for exception
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: exception raised
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('true', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        self.assertRaises(Exception, lambda:
                          attempt.ask("What is the status of <awesomesauce.txt>?"))

    @requirements(['#0100'])
    @mock.patch('subprocess.Popen')
    def test_mock_in_repo_yes(self, mock_subproc_popen):
        """
        test mock is_file_in_repo yes
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: yes
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('true', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask("Is the <requirements.txt> in the repo?")
        self.assertEqual(result, "Yes")

    @requirements(['#0100'])
    @mock.patch('subprocess.Popen')
    def test_mock_in_repo_nonexistent(self, mock_subproc_popen):
        """
        test mock is_file_in_repo no nonexistent
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: no, nonexistent
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('true', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask("Is the <awesomesauce.txt> in the repo?")
        self.assertEqual(result, "No")

    @requirements(['#0101'])
    @mock.patch('source.git_utils.get_diff_files')
    def test_mock_diff_true(self, mock_diff_files):
        """
        Test mock get_diff_files true
        :param mock_diff_files:
        :return: assertion: file modified locally
        """
        mock_file = 'requirements.txt'
        mock_diff_files.return_value = os.path.abspath(mock_file)
        result = get_git_file_info(mock_file)
        self.assertEqual(result, 'requirements.txt has been modified locally')

    @requirements(['#0101'])
    @mock.patch('source.git_utils.get_untracked_files')
    @mock.patch('source.git_utils.get_diff_files')
    def test_mock_untracked_true(self, mock_diff_files, mock_untracked_files):
        """
        Test mock untracked files true
        :param mock_diff_files: mock of get_diff_files
        :param mock_untracked_files: mock of get_untracked_files
        :return: assertion: file not checked in
        """
        mock_file = 'requirements.txt'
        mock_diff_files.return_value = ""
        mock_untracked_files.return_value = os.path.abspath(mock_file)
        result = get_git_file_info(mock_file)
        self.assertEqual(result, 'requirements.txt has been not been checked in')

    @requirements(['#0101'])
    @mock.patch('source.git_utils.get_untracked_files')
    def test_mock_untracked_files(self, mock_get_untracked_files):
        """
        Test mock get untracked files true
        :param mock_get_untracked_files: mock of get_untracked_files
        :return: assertion: True
        """
        mock_get_untracked_files.return_value = 'yay_testing'
        result = has_untracked_files('requirements.txt')
        self.assertEqual(result, True)

    @requirements(['#0101'])
    @mock.patch('source.git_utils.has_diff_files')
    def test_mock_dirty_false(self, mock_is_repo_dirty):
        """
        Test mock is_repo_dirty false
        :param mock_is_repo_dirty: mock of is_repo_dirty
        :return: assertion: false
        """
        mock_is_repo_dirty.return_value = ''
        result = is_repo_dirty('requirements.txt')
        self.assertEqual(result, False)

    @requirements(['#0101'])
    @mock.patch('source.git_utils.get_diff_files')
    def test_mock_git_diff_false(self, mock_get_diff_files):
        """
        Test mock get_git_file_info false
        :param mock_get_diff_files: mock of get_diff_files
        :return: assertion: false
        """
        mock_file = mock_get_diff_files('requirements.txt')
        mock_file.return_value = False
        self.assertFalse(has_diff_files('requirements.txt'))

    @requirements(['#0101'])
    @mock.patch('source.git_utils.get_untracked_files')
    def test_mock_git_untracked_false(self, mock_get_untracked_files):
        """
        Test mock get_git_file_info untracked false
        :param mock_get_untracked_files: mock of get_untracked_files
        :return: assertion: false
        """
        mock_file = mock_get_untracked_files('requirements.txt')
        mock_file.return_value = False
        self.assertFalse(has_untracked_files('requirements.txt'))

    @requirements(['#0101'])
    @mock.patch('subprocess.Popen')
    def test_mock_up_to_date(self, mock_subproc_popen):
        """
        Test mock is file up to date
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: up to date
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('', '')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask("What is the status of <requirements.txt>?")
        self.assertEqual(result, "requirements.txt is up to date")

    @requirements(['#0101'])
    @mock.patch('subprocess.Popen')
    def test_mock_git_dirty(self, mock_subproc_popen):
        """
        Test mock get_git_file_info dirty
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: dirty repo
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('true', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask("What is the status of <requirements.txt>?")
        self.assertEqual(result, "requirements.txt is a dirty repo")

    @requirements(['#0102'])
    @mock.patch('subprocess.Popen')
    def test_mock_get_file_info(self, mock_subproc_popen):
        """
        Test mock get_file_info
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: requirements.txt
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('requirements.txt', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask("What is the deal with <requirements.txt>?")
        self.assertEqual(result, 'requirements.txt')

    @requirements(['#0103'])
    @mock.patch('subprocess.Popen')
    def test_mock_get_repo_branch(self, mock_subproc_popen):
        """
        Test mock get_repo_branch
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: requirements.txt
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('requirements.txt', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask('What branch is <requirements.txt>?')
        self.assertEqual(result, 'requirements.txt')

    @requirements(['#0104'])
    @mock.patch('subprocess.Popen')
    def test_mock_get_repo_url(self, mock_subproc_popen):
        """
        Test mock get_repo_url
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: requirements.txt
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('requirements.txt', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask('Where did <requirements.txt> come from?')
        self.assertEqual(result, 'requirements.txt')

    @requirements(['#0105'])
    @mock.patch('subprocess.Popen')
    def test_mock_get_repo_root(self, mock_subproc_popen):
        """
        Test mock get_repo_root
        :param mock_subproc_popen: mock of subprocess Popen
        :return: assertion: requirements.txt
        """
        process_mock = mock.Mock()
        attrs = {'communicate.return_value': ('requirements.txt', 'File not found')}
        process_mock.configure_mock(**attrs)
        mock_subproc_popen.return_value = process_mock
        attempt = Interface()
        result = attempt.ask('What is root of <requirements.txt>?')
        self.assertEqual(result, 'requirements.txt')

