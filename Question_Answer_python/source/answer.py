"""
Derek Edwards
Source code for job stories
"""
import datetime
import getpass
import socket
import random


def get_date_and_time():
    """
    Return current date and time in a string.
    :return: current date and time
    """
    now = datetime.datetime.now()
    return "Current date and time: " + now.strftime("%Y-%m-%d %H:%M")


def fib(digit):
    """
    Calculate and return specified digit in fibonacci sequence.
    :param digit: position in sequence
    :return: specified digit
    """
    var_a, var_b = 1, 1
    if digit == 0:
        return 0
    for i in range(digit-1):
        var_a, var_b = var_b, var_a+var_b
    return var_a


def make_pi():
    """
    Calculate the value of pi up to 1,000 digits.
    :return: value of pi up to 1,000 digits
    """
    var_q, var_r, var_t, var_k, var_m, var_x = 1, 0, 1, 1, 3, 3
    for j in range(1000):
        if 4 * var_q + var_r - var_t < var_m * var_t:
            yield var_m
            var_q, var_r, var_t, var_k, var_m, var_x = 10*var_q, 10*(var_r-var_m*var_t),\
                var_t, var_k, (10*(3*var_q+var_r))//var_t - 10*var_m, var_x
        else:
            var_q, var_r, var_t, var_k, var_m, var_x = var_q*var_k, (2*var_q+var_r)*var_x,\
                var_t*var_x, var_k+1, (var_q*(7*var_k+2)+var_r*var_x)//(var_t*var_x), var_x+2


def get_pi(digit):
    """
    Use make_pi() function to determine n digit in pi.
    :param digit: desired digit of pi
    :return: specified digit of pi
    """
    iterator = 0
    for i in make_pi():
        iterator += 1
        if iterator == digit:
            return i


def clear_memory(interface_object):
    """
    Clear questions and answers recorded in the system.
    :param interface_object: Object that contains a list of previously asked
    questions and answers
    :return: void
    """
    interface_object.question_answers.clear()


def hal_at_the_door():
    """
    Answer the door.
    :return: Creepy message
    """
    return "I\'m afraid I can\'t do that {0}".format(getpass.getuser())


def convert_units(value, unit_from, unit_to):
    """
    Convert value units from one type to another in metric.
    :param value: Number of units to convert
    :param unit_from: Unit to convert
    :param unit_to: Unit to be converted to
    :return: Number and converted units
    """
    metric = {'nanometers': .000000001, 'micrometers': .000001, 'millimeters': .001,
              'centimeters': .01, 'decimeters': .1, 'meters': 1, 'dekameters': 10,
              'hectometers': 100, 'kilometers': 1000, 'megameters': 1000000,
              'gigameters': 1000000000}
    return '{0} {1}'.format(((metric[unit_from]/metric[unit_to]) * value), unit_to)


def meaning_of_life():
    """
    Calculate the meaning of life.
    :return: The meaning of life
    """
    return "42"


def host_name():
    """
    Retrieve server host name.
    :return: Server host name
    """
    return socket.gethostname()


def number_of_sides(sides):
    """
    Retrieve the shape that corresponds to the number of sides given.
    :param sides: The number of sides given
    :return: The name of the shape
    """
    shapes = {1: 'no shape', 2: 'line', 3: 'triangle', 4: 'square', 5: 'pentagon',
              6: 'hexagon', 7: 'heptagon', 8: 'octagon', 9: 'enneagon', 10: 'decagon',
              11: 'hendecagon', 12: 'dodecagon', 13: 'tridecagon',
              14: 'tetradecagon', 15: 'pendedecagon'}
    return shapes[sides]


def random_fortune():
    """
    Return a random fortune.
    :return: Random fortune
    """
    fortunes = ['Even a fish can stay out of trouble if it keeps its mouth shut',
                'Make good decisions in life',
                'Why do today what you can put off until tomorrow?',
                'What is today but yesterday\'s tomorrow?',
                'Carpe Diem', 'YOLO']
    return random.choice(fortunes)


def abs_value(number):
    """
    Calculate and return the absolute value of the given number.
    :param number: Number to calculate the absolute value of
    :return: Absolute value of given number
    """
    return abs(number)


def caesar_encrypt(message, shift):
    """
    Encrypt the message with a caesar cipher.
    :param message: Message to encrypt
    :param shift: Number of spaces to shift
    :return: Encrypted message
    """
    cipher_text = ""
    for item in message:
        if item.isalpha():
            stay_in_alphabet = ord(item) + shift
        if stay_in_alphabet > ord('z'):
            stay_in_alphabet -= 26
        final_letter = chr(stay_in_alphabet)
        cipher_text += final_letter
    return cipher_text


def break_cipher(message):
    """
    Calculate and return a list of possible shifts for a sequence of characters.
    :param message: Sequence of characters
    :return: List of possible shifts for message
    """
    cipher_text = ""
    i = 0
    while i < 24:
        cipher_text += "\n"
        for item in message:
            if item.isalpha():
                stay_in_alphabet = ord(item) + i
            if stay_in_alphabet > ord('z'):
                stay_in_alphabet -= 26
            final_letter = chr(stay_in_alphabet)
            cipher_text += final_letter
        i += 1
    return cipher_text


def days_until_christmas():
    """
    Calculate and returns the number of days until Christmas
    :return: Number of days until Christmas
    """
    today = datetime.date.today()
    christmas = datetime.date(2016, 12, 25)
    diff = christmas - today
    return diff.days


def logic_gate(question):
    """
    Calculate the return value for two inputs of a specified logic gate.
    :param question: Logic gate and two input values
    :return: Result of the two inputs in specified gate
    """
    new_string = question.replace("?", "")
    q_args = new_string.split(' ')
    if len(q_args) == 8:
        var_x = float(q_args[5])
        gate = q_args[6]
        var_y = float(q_args[7])
        if gate == 'OR':
            if var_x or var_y == 1:
                return 1
            else:
                return 0
        elif gate == 'AND':
            if var_x and var_y == 1:
                return 1
            else:
                return 0
        elif gate == 'NAND':
            if var_x and var_y == 1:
                return 0
            else:
                return 1
        elif gate == 'NOR':
            if var_x or var_y == 1:
                return 0
            else:
                return 1
        elif gate == 'XOR':
            if var_x == 0 and var_y == 1 or var_y == 0 and var_x == 1:
                return 1
            else:
                return 0
        else:
            if (var_x == 0 and var_y == 1) or (var_y == 0 and var_x == 1):
                return 0
            else:
                return 1
    else:
        return 'invalid question'
