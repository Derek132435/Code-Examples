"""
Derek Edwards
Job story test file
"""

import datetime
import socket
import getpass
from unittest import TestCase
from source.main import Interface
from source.answer import get_date_and_time, fib, get_pi, clear_memory,\
    hal_at_the_door, meaning_of_life, host_name, number_of_sides, random_fortune, \
    abs_value, caesar_encrypt, break_cipher, days_until_christmas, logic_gate
from test.plugins.ReqTracer import story


class TestGetAnswer(TestCase):
    """
    Test class for job stories in answer.py
    """

    @story('When I ask "What time is it?" I want to be given the current date/time so I can'
           ' stay up to date')
    def test_job_story_case_time(self):
        """
        Test job story case date_and_time
        :return: assertion that the system returns the correct time when asked
        """
        now = datetime.datetime.now()
        inquiry = Interface()
        date_time = 'Current date and time: ' + now.strftime("%Y-%m-%d %H:%M")
        inquiry.ask("What time is it?")
        inquiry.teach(get_date_and_time())
        result = inquiry.ask("What time is it?")
        self.assertEqual(result, date_time)

    @story('When I ask "What is the n digit of fibonacci" I want to receive the answer so'
           ' I don\'t have to figure it out myself')
    def test_job_story_case_fib(self):
        """
        Test job story case fib
        :return: assertion that the system returns the correct digit of the fibonacci
        sequence
        """
        inquiry = Interface()
        inquiry.ask("What is the 5 digit of fibonacci?")
        inquiry.teach(fib(9))
        result = inquiry.ask("What is the 5 digit of fibonacci?")
        self.assertEqual(result, 34)
        inquiry.ask("What is the 0 digit of fibonacci?")
        inquiry.correct(fib(0))
        result = inquiry.ask("What is the 0 digit of fibonacci?")
        self.assertEqual(result, 0)

    @story('When I ask \"What is the n digit of pi\" I want to receive the answer so I'
           ' don\'t have to figure it out myself')
    def test_job_story_case_get_pi(self):
        """
        Test job story case get_pi()
        :return: assertion that the system returns the correct digit of pi when asked
        """
        inquiry = Interface()
        pi_value = 3
        inquiry.ask("What is the 16 digit of pi?")
        inquiry.teach(get_pi(16))
        result = inquiry.ask("What is the 16 digit of pi?")
        self.assertEqual(result, pi_value)

    @story('When I ask "Please clear memory" I want the application to clear user set '
           'questions and answers so I can reset the application')
    def test_job_story_case_clear(self):
        """
        Test job story case clear memory
        :return: assertion that the system clears previous questions when asked
        """
        inquiry = Interface()
        inquiry.ask("What is the 16 digit of pi?")
        inquiry.teach(get_pi(16))
        inquiry.ask("Will you please clear memory?")
        inquiry.teach(clear_memory(inquiry))
        result = inquiry.ask("What is the 16 digit of pi?")
        self.assertEqual(result, 'I don\'t know, please provide the answer')

    @story('When I say "Open the door hal", I want the application to say'
           ' "I\'m afraid I can\'t do that <user name>" so I know that is not an option')
    def test_job_story_case_door(self):
        """
        Test job story case hal_at_the_door
        :return: assertion that the system returns the correct answer and username
        """
        inquiry = Interface()
        inquiry.ask("Will you open the door hal?")
        inquiry.teach(hal_at_the_door())
        result = inquiry.ask("Will you open the door hal?")
        self.assertEqual(result, 'I\'m afraid I can\'t do that {0}'.format(getpass.getuser()))

    @story('When I ask "Convert <number> <units> to <units>" I want to receive the'
           ' converted value and units so I can know the answer.')
    def test_job_story_case_convert(self):
        """
        Test job story case convert_units.
        :return: assertion that the system returns the correct number of converted units
        """
        inquiry = Interface()
        result = inquiry.ask("Convert 5 centimeters to millimeters")
        self.assertEqual(result, "50.0 millimeters")

    @story('When I ask for a numeric conversion I want at least 10 different units I '
           'can convert from/to')
    def test_job_story_case_ten_convert(self):
        """
        Test job story case ten_conversions.
        :return: assertion that the system can perform conversions between at least 10
        different units
        """
        inquiry = Interface()
        result = inquiry.ask("Convert 1 gigameters to megameters")
        self.assertEqual(result, "1000.0 megameters")
        result = inquiry.ask("Convert 1 kilometers to hectometers")
        self.assertEqual(result, "10.0 hectometers")
        result = inquiry.ask("Convert 1 dekameters to meters")
        self.assertEqual(result, "10.0 meters")
        result = inquiry.ask("Convert 1 decimeters to centimeters")
        self.assertEqual(result, "10.0 centimeters")
        result = inquiry.ask("Convert 1 millimeters to micrometers")
        self.assertEqual(result, "1000.0 micrometers")
        result = inquiry.ask("Convert 1 micrometers to nanometers")
        self.assertEqual(result, "1000.0 nanometers")

    @story('When I ask "What is the meaning of life, the universe, and everything?" I want'
           ' to be given the answer so that I know what to do with my life')
    def test_job_story_case_meaning(self):
        """
        Test job story case meaning_of_life().
        :return: assertion that the system returns the correct meaning of life when asked
        """
        inquiry = Interface()
        inquiry.ask("What is the meaning of life, the universe, and everything?")
        inquiry.teach(meaning_of_life())
        result = inquiry.ask("What is the meaning of life, the universe, and everything?")
        self.assertEqual(result, "42")

    @story('When I ask "What is this computers hostname?" I want to be given the answer so '
           'that I know which computer I am using')
    def test_job_story_case_name(self):
        """
        Test job story case computer_name().
        :return: assertion that the system returns the computer name when asked
        """
        inquiry = Interface()
        inquiry.ask("What is this computer\'s hostname?")
        inquiry.teach(host_name())
        result = inquiry.ask("What is this computer\'s hostname?")
        self.assertEqual(result, socket.gethostname())

    @story('When I ask "What shape has n sides?" I want to receive an answer to'
           ' help with my geometry homework')
    def test_job_story_case_sides(self):
        """
        Test job story case number_of_sides().
        :return: assertion that the system returns the correct shapes corresponding to the
        number of sides
        """
        inquiry = Interface()
        inquiry.ask("What shape has 5 sides?")
        inquiry.teach(number_of_sides(5))
        result = inquiry.ask("What shape has 5 sides?")
        self.assertEqual(result, 'pentagon')

    @story('When I ask "What should I keep in mind today?" I want to receive a '
           'random fortune so that I can feel better')
    def test_job_story_case_fortune(self):
        """
        Test job story case random_fortune().
        :return: assertion that the system returns a string of a random fortune.
        """
        inquiry = Interface()
        inquiry.ask("What should I keep in mind today?")
        inquiry.teach(random_fortune())
        result = inquiry.ask("What should I keep in mind today?")
        assert isinstance(result, str)

    @story('When I ask "What is the absolute value of n?" I want to receive an '
           'answer so that I don\'t have to calculate it myself')
    def test_job_story_case_abs_value(self):
        """
        Test job story case abs_value().
        :return: assertion that the system returns the correct absolute value
        of a number
        """
        inquiry = Interface()
        inquiry.ask("What is the absolute value of -6?")
        inquiry.teach(abs_value(-6))
        result = inquiry.ask("What is the absolute value of -6?")
        self.assertEqual(result, 6)

    @story('When I ask "What is x in an n level caesar cipher?" I want to receive '
           'an answer so that I can encrypt my private information')
    def test_job_story_case_encrypt(self):
        """
        Test job story case caesar_encrypt().
        :return: assertion that the system returns the correct shift caesar cipher
        for a given message
        """
        inquiry = Interface()
        inquiry.ask("What is 'mysecretpassword' in a 5 level caesar cipher?")
        inquiry.teach(caesar_encrypt('mysecretpassword', 5))
        result = inquiry.ask("What is 'mysecretpassword' in a 5 level caesar cipher?")
        self.assertEqual(result, 'rdxjhwjyufxxbtwi')

    @story('When I ask "What are the possible caesar shifts of x?" I would like '
           'to receive a list of all possible answers so that I can retrieve '
           'my information if I forget what shift I used')
    def test_job_story_case_decrypt(self):
        """
        Test job story case break_cipher().
        :return: assertion that the system returns all 24 possible shifts of a given
        caesar cipher encrypted message.
        """
        inquiry = Interface()
        inquiry.ask("What are the possible caesar shifts of rdxjhwjyufxxbtwi?")
        inquiry.teach(break_cipher('rdxjhwjyufxxbtwi'))
        result = inquiry.ask("What are the possible caesar shifts of rdxjhwjyufxxbtwi?")
        self.assertEqual(result, '\nrdxjhwjyufxxbtwi\nseykixkzvgyycuxj\ntfzljylawhzzdvyk\n'
                                 'ugamkzmbxiaaewzl\nvhbnlancyjbbfxam\nwicombodzkccgybn\n'
                                 'xjdpncpealddhzco\nykeqodqfbmeeiadp\nzlfrpergcnffjbeq\n'
                                 'amgsqfshdoggkcfr\nbnhtrgtiephhldgs\ncoiushujfqiimeht\n'
                                 'dpjvtivkgrjjnfiu\neqkwujwlhskkogjv\nfrlxvkxmitllphkw\n'
                                 'gsmywlynjummqilx\nhtnzxmzokvnnrjmy\niuoaynaplwoosknz\n'
                                 'jvpbzobqmxpptloa\nkwqcapcrnyqqumpb\nlxrdbqdsozrrvnqc\n'
                                 'mysecretpassword\nnztfdsfuqbttxpse\noaugetgvrcuuyqtf')

    @story('When I ask "How many days until Christmas?" I want to receive the exact number'
           ' of days so that I can prepare for the holidays')
    def test_job_story_case_christmas(self):
        """
        Test job story case days_until_christmas().
        :return: assertion that the system returns the correct number of days until christmas
        """
        inquiry = Interface()
        inquiry.ask("How many days until Christmas?")
        inquiry.teach(days_until_christmas())
        result = inquiry.ask("How many days until Christmas?")
        today = datetime.date.today()
        christmas = datetime.date(2016, 12, 25)
        diff = christmas - today
        self.assertEqual(result, diff.days)

    @story('When I ask "What is the output of x gate y?" I want it to perform the '
           'appropriate logic and return the answer to me so that I know how logic gates work')
    def test_job_story_case_logic_gate(self):
        """
        Test job story case logic_gate().
        :return: assertion that the system returns the correct value for the given inputs and
        logic gate
        """

        result = logic_gate("What is the output of 0 OR gate 0?")
        self.assertEqual(result, 'invalid question')

        inquiry = Interface()
        inquiry.ask("What is the output of 1 OR 0?")
        inquiry.teach(logic_gate("What is the output of 1 OR 0?"))
        result = inquiry.ask("What is the output of 1 OR 0?")
        self.assertEqual(result, 1)

        result = logic_gate("What is the output of 0 OR 0?")
        self.assertEqual(result, 0)

        result = logic_gate("What is the output of 1 AND 1?")
        self.assertEqual(result, 1)

        result = logic_gate("What is the output of 1 AND 0?")
        self.assertEqual(result, 0)

        result = logic_gate("What is the output of 0 NAND 0?")
        self.assertEqual(result, 1)

        result = logic_gate("What is the output of 1 NAND 1?")
        self.assertEqual(result, 0)

        result = logic_gate("What is the output of 0 NOR 0?")
        self.assertEqual(result, 1)

        result = logic_gate("What is the output of 1 NOR 0?")
        self.assertEqual(result, 0)

        result = logic_gate("What is the output of 1 XOR 0?")
        self.assertEqual(result, 1)

        result = logic_gate("What is the output of 1 XOR 1?")
        self.assertEqual(result, 0)

        result = logic_gate("What is the output of 1 XNOR 0?")
        self.assertEqual(result, 0)

        result = logic_gate("What is the output of 1 XNOR 1?")
        self.assertEqual(result, 1)
