"""
Derek Edwards
Test for source.shape_checker
"""
from unittest import TestCase
from source.shape_checker import get_triangle_type, get_quadrilateral_type
from source.main import Interface
from test.plugins.ReqTracer import requirements


class TestGetTriangleType(TestCase):
    """
    Test class for source.shape_checker
    """

    @requirements(['#0001', '#0002'])
    def test_tri_equilateral_all_int(self):
        """
        Test triangle equilateral all integer input
        :return: assertion: equilateral
        """
        result = get_triangle_type(1, 1, 1)
        self.assertEqual(result, 'equilateral')

    @requirements(['#0001', '#0002'])
    def test_tri_scalene_all_int(self):
        """
        Test triangle scalene all integer input
        :return: assertion: scalene
        """
        result = get_triangle_type(1, 2, 3)
        self.assertEqual(result, 'scalene')

    @requirements(['#0001', '#0002'])
    def test_tri_isosceles_all_int(self):
        """
        Test triangle isosceles all integer input
        :return: assertion: isosceles
        """
        result = get_triangle_type(1, 1, 3)
        self.assertEqual(result, 'isosceles')

    @requirements(['#0001', '#0002'])
    def test_tri_isosceles_neg(self):
        """
        Test triangle isosceles negative input
        :return: assertion: invalid
        """
        result = get_triangle_type(-1, 1, 1)
        self.assertEqual(result, 'invalid')

    @requirements(['#0002'])
    def test_tri_invalid_all_char(self):
        """
        Test triangle invalid char input
        :return: assertion: invalid
        """
        result = get_triangle_type('a', 'b', 'c')
        self.assertEqual(result, 'invalid')

    @requirements(['#0001', '#0002'])
    def test_tri_scalene_all_float(self):
        """
        Test triangle scalene all float input
        :return: assertion: scalene
        """
        result = get_triangle_type(1.2, 1.3, 1.1)
        self.assertEqual(result, 'scalene')

    @requirements(['#0001', '#0002'])
    def test_tri_equilateral_tuple(self):
        """
        Test triangle equilateral tuple input
        :return: assertion: equilateral
        """
        var_t = (1, 1, 1)
        result = get_triangle_type(var_t)
        self.assertEqual(result, 'equilateral')

    @requirements(['#0001', '#0002'])
    def test_tri_equilateral_list(self):
        """
        Test triangle equilateral list input
        :return: assertion: equilateral
        """
        var_l = [1, 1, 1]
        result = get_triangle_type(var_l)
        self.assertEqual(result, 'equilateral')

    @requirements(['#0001', '#0002'])
    def test_tri_equilateral_dict(self):
        """
        Test triangle equilateral dictionary input
        :return: assertion: equilateral
        """
        var_d = {'a': 1, 'b': 1, 'c': 1}
        result = get_triangle_type(var_d)
        self.assertEqual(result, 'equilateral')


class TestGetQuadrilateralType(TestCase):
    """
    Get quadrilateral test class
    """

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_square_int(self):
        """
        Test quadrilateral square all int input
        :return: assertion: square
        """
        result = get_quadrilateral_type(1, 1, 1, 1, 90, 90, 90, 90)
        self.assertEqual(result, 'square')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_rect_all_int(self):
        """
        Test quadrilateral rectangle all int input
        :return: assertion: rectangle
        """
        result = get_quadrilateral_type(1, 1, 2, 2, 90, 90, 90, 90)
        self.assertEqual(result, 'rectangle')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_rhombus_all_int(self):
        """
        Test quadrilateral rhombus all int input
        :return: assertion: rhombus
        """
        result = get_quadrilateral_type(1, 1, 1, 1, 40, 40, 140, 140)
        self.assertEqual(result, 'rhombus')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_disconnected(self):
        """
        Test quadrilateral disconnected all int input
        :return: assertion: disconnected
        """
        result = get_quadrilateral_type(1, 1, 1, 1, 41, 40, 140, 140)
        self.assertEqual(result, 'disconnected')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_neg(self):
        """
        Test quadrilateral negative int input
        :return: assertion: invalid
        """
        result = get_quadrilateral_type(-1, 1, 1, 1, -90, 90, 90, 90)
        self.assertEqual(result, 'invalid')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_square_char(self):
        """
        Test quadrilateral invalid char input
        :return: assertion: invalid
        """
        result = get_quadrilateral_type('a', 1, 1, 1, 'b', 90, 90, 90)
        self.assertEqual(result, 'invalid')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_square_all_float(self):
        """
        Test quadrilateral square all float input
        :return: assertion: square
        """
        result = get_quadrilateral_type(1.1, 1.1, 1.1, 1.1, 90, 90, 90, 90)
        self.assertEqual(result, 'square')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_rhombus_all_float(self):
        """
        Test quadrilateral rhombus all float input
        :return: assertion: rhombus
        """
        result = get_quadrilateral_type(1.1, 1.1, 1.1, 1.1, 139.5, 40.5, 40.5, 139.5)
        self.assertEqual(result, 'rhombus')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_square_tuple(self):
        """
        Test quadrilateral square tuple input
        :return: assertion: square
        """
        var_t = (1, 1, 1, 1, 90, 90, 90, 90)
        result = get_quadrilateral_type(var_t)
        self.assertEqual(result, 'square')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_square_list(self):
        """
        Test quadrilateral square list input
        :return: assertion: square
        """
        var_l = [1, 1, 1, 1, 90, 90, 90, 90]
        result = get_quadrilateral_type(var_l)
        self.assertEqual(result, 'square')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_quad_square_dict(self):
        """
        Test quadrilateral square dictionary input
        :return: assertion: square
        """
        var_d = {'a': 1, 'b': 1, 'c': 1, 'd': 1, 'alpha': 90, 'beta': 90, 'theta': 90, 'gamma': 90}
        result = get_quadrilateral_type(var_d)
        self.assertEqual(result, 'square')

    @requirements(['#0003', '#0004', '#0005'])
    def test_get_unknown_quad(self):
        """
        Test quadrilateral unknown all int input
        :return: assertion: unknown quadrilateral
        """
        var_d = {'a': 1, 'b': 2, 'c': 3, 'd': 4, 'alpha': 88, 'beta': 89, 'theta': 91, 'gamma': 92}
        result = get_quadrilateral_type(var_d)
        self.assertEqual(result, "unknown quadrilateral")


class TestQuestionAnswerInterface(TestCase):
    """
    test interface ask
    """
    @requirements(['#0006'])
    def test_ask_not_string(self):
        """
        Test ask function not string
        :return: assertion: exception: not string
        """
        inquiry = Interface()
        self.assertRaises(Exception, lambda: inquiry.ask(12))

    @requirements(['#0006', '#0009'])
    def test_ask_no_question_mark(self):
        """
        Test ask function no question mark
        :return: assertion: Was that a question?
        """
        inquiry = Interface()
        result = inquiry.ask('What type of triangle is isosceles')
        self.assertEqual(result, "Was that a question?")

    @requirements(['#0006', '#0007'])
    def test_ask_tri_no_answer(self):
        """
        Test ask function triangle no answer
        :return: assertion: ask to provide answer
        """
        inquiry = Interface()
        result = inquiry.ask('What type of triangle is isosceles?')
        self.assertEqual(result, "I don't know, please provide the answer")

    @requirements(['#0006', '#0007'])
    def test_ask_quad_no_answer(self):
        """
        Test ask function quadrilateral no answer
        :return: assertion: ask to provide answer
        """
        inquiry = Interface()
        result = inquiry.ask('How many sides does a quadrilateral have?')
        self.assertEqual(result, "I don't know, please provide the answer")

    @requirements(['#0007', '#0008'])
    def test_ask_tri_no_keyword(self):
        """
        Test ask function triangle no keyword
        :return: assertion: Was that a question?
        """
        inquiry = Interface()
        result = inquiry.ask('many sides does a triangle have?')
        self.assertEqual(result, "Was that a question?")

    @requirements(['#0007', '#0008'])
    def test_ask_quad_no_keyword(self):
        """
        Test ask function quadrilateral no keyword
        :return: assertion: Was that a question?
        """
        inquiry = Interface()
        result = inquiry.ask('many sides does a quadrilateral have?')
        self.assertEqual(result, "Was that a question?")

    @requirements(['#0010', '#0013'])
    def test_ask_tri_isosceles(self):
        """
        Test ask function triangle isosceles
        :return: assertion: isosceles
        """
        inquiry = Interface()
        result = inquiry.ask('What type of triangle is 1 1 3?')
        self.assertEqual(result, 'isosceles')

    @requirements(['#0010', '#0013'])
    def test_ask_quad_square(self):
        """
        Test ask function quadrilateral square
        :return: assertion: square
        """
        inquiry = Interface()
        result = inquiry.ask('What type of quadrilateral is 1 1 1 1 90 90 90 90?')
        self.assertEqual(result, 'square')

    @requirements(['#0011', '#0014'])
    def test_ask_bad_question(self):
        """
        Test ask function bad question
        :return: assertion: provide answer
        """
        inquiry = Interface()
        result = inquiry.ask('What kind of shape has sides 1 1 3?')
        self.assertEqual(result, "I don't know, please provide the answer")

    @requirements(['#0012', '#0014'])
    def test_ask_no_values(self):
        """
        Test ask function no values
        :return: assertion: invalid
        """
        inquiry = Interface()
        result = inquiry.ask('What type of triangle is this?')
        self.assertEqual(result, "invalid")

    @requirements(['#0015', '#0016', '#0020'])
    def test_ask_teach_previous(self):
        """
        Test teach function, teach previous answer
        :return: assertion: isosceles
        """
        inquiry = Interface()
        answer = inquiry.ask('What type of triangle is 1 1 3?')
        inquiry.teach(answer)
        result = answer
        self.assertEqual(result, "isosceles")

    @requirements(['#0015', '#0016', '#0017', '#0020', '#0021'])
    def test_ask_teach_no_previous(self):
        """
        Test teach function, no previous question
        :return: assertion: ask a question
        """
        inquiry = Interface()
        answer = None
        result = inquiry.teach(answer)
        self.assertEqual(result, 'Please ask a question first')

    @requirements(['#0015', '#0016', '#0020', '#0018'])
    def test_ask_no_teach(self):
        """
        Test teach function, wrong answer
        :return: assertion: refuse answer
        """
        inquiry = Interface()
        inquiry.ask('What type of triangle is  1 1 1?')
        result = inquiry.teach('trapezoid')
        self.assertEqual(result, 'I don\'t know about that. I was taught differently')

    @requirements(['#0015', '#0016', '#0019', '#0020'])
    def test_ask_correct_tri(self):
        """
        Test correct function, triangle polygon
        :return: assertion: none
        """
        inquiry = Interface()
        inquiry.ask('What type of triangle is  1 1 1?')
        result = inquiry.correct('polygon')
        self.assertEqual(result, None)

    @requirements(['#0015', '#0016', '#0019', '#0020'])
    def test_ask_correct_quad(self):
        """
        Test correct function, quadrilateral polygon
        :return: assertion: none
        """
        inquiry = Interface()
        inquiry.ask('What type of quadrilateral is  1 1 1 1 90 90 90 90?')
        result = inquiry.correct('polygon')
        self.assertEqual(result, None)

    @requirements(['#0015', '#0016', '#0019', '#0020'])
    def test_ask_no_correct(self):
        """
        Test correct function, no question
        :return: assertion: ask question first
        """
        inquiry = Interface()
        result = inquiry.correct('polygon')
        self.assertEqual(result, 'Please ask a question first')

    @requirements(['#0015', '#0016', '#0019', '#0020'])
    def test_ask_too_many_params(self):
        """
        Test ask function, too many parameters
        :return: assertion: exception: too many parameters
        """
        inquiry = Interface()
        self.assertRaises(Exception, lambda: inquiry.ask('What type of'
                                                         ' quadrilateral is  '
                                                         '1 1 1 1 90 90 90 90 5?'))
