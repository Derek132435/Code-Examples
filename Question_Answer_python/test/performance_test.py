"""
Derek Edwards
Performance test file
"""
import time
from unittest import TestCase
from test.plugins.ReqTracer import requirements
from source.main import Interface
from source.answer import fib, number_of_sides, logic_gate, caesar_encrypt


class TestGetTime(TestCase):
    """
    Performance test class
    """

    @requirements(['#0050', '#0051', '#0052'])
    def test_performance_log_file(self):
        """
        Test how long it takes to write a test to log_file.
        :return: Assert that it is less than 50ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask('What type of triangle is 1 1 3?')
        end = time.clock()
        result = (end - start)
        print result
        assert result <= 0.050

    @requirements(['#0053'])
    def test_performance_time_check(self):
        """
        Test how long it takes to return the date and time
        :return: Assert that it is less than 5ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What time is it?")
        end = time.clock()
        result = (end - start)
        print result
        assert result <= 0.015

    @requirements(['#0054'])
    def test_performance_fibonacci_500(self):
        """
        Test how long it takes to return 500th digit from the fibonacci sequence
        :return: Assert that it is less than 5ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What is the 500 digit of fibonacci?")
        inquiry.teach(fib(500))
        inquiry.ask("What is the 500 digit of fibonacci?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015

    @requirements(['#0054'])
    def test_performance_fibonacci_1000(self):
        """
        Test how long it takes to return 1,000th digit from the fibonacci sequence
        :return: Assert that it is less than 5ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What is the 1000 digit of fibonacci?")
        inquiry.teach(fib(1000))
        inquiry.ask("What is the 1000 digit of fibonacci?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015

    @requirements(['#0055'])
    def test_performance_shape_sides_5(self):
        """
        Test how long it takes to return the name of a 5 sided shape
        :return: Assert that it is less than 5ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What shape has 5 sides?")
        inquiry.teach(number_of_sides(5))
        inquiry.ask("What shape has 5 sides?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015

    @requirements(['#0055'])
    def test_performance_shape_sides_14(self):
        """
        Test how long it takes to return the name of a 14 sided shape
        :return: Assert that it is less than 5ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What shape has 14 sides?")
        inquiry.teach(number_of_sides(14))
        inquiry.ask("What shape has 14 sides?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015

    @requirements(['#0056'])
    def test_performance_caesar_5(self):
        """
        Test how long it takes to encrypt a message with a shift of 5
        :return: Assert that it is less than 5ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What is 'mysecretpassword' in a 5 level caesar cipher?")
        inquiry.teach(caesar_encrypt('mysecretpassword', 5))
        inquiry.ask("What is 'mysecretpassword' in a 5 level caesar cipher?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015

    @requirements(['#0056'])
    def test_performance_caesar_23(self):
        """
        Test how long it takes to encrypt a message with a shift of 23
        :return: Assert that it is less than 5ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What is 'mysecretpassword' in a 23 level caesar cipher?")
        inquiry.teach(caesar_encrypt('mysecretpassword', 23))
        inquiry.ask("What is 'mysecretpassword' in a 23 level caesar cipher?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015

    @requirements(['#0057'])
    def test_performance_logic_or(self):
        """
        Test how long it takes to return the output of an OR gate
        :return: Assert that it is less than 8ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What is the output of 1 OR 0?")
        inquiry.teach(logic_gate("What is the output of 1 OR 0?"))
        inquiry.ask("What is the output of 1 OR 0?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015

    @requirements(['#0057'])
    def test_performance_logic_and(self):
        """
        Test how long it takes to return the output of an AND gate
        :return: Assert that it is less than 8ms
        """
        inquiry = Interface()
        start = time.clock()
        inquiry.ask("What is the output of 1 AND 0?")
        inquiry.teach(logic_gate("What is the output of 1 AND 0?"))
        inquiry.ask("What is the output of 1 AND 0?")
        end = time.clock()
        result = (end - start)
        assert result <= 0.015
