"""
:mod:`source.source1` -- Example source code
============================================

The following example code returns the type of triangle or quadrilateral
given side lengths and, in the case of quadrilateral, angles

disabled pylint E1101: Parameters are fine
disabled pylint R0913: All arguments are necessary
disabled pylint R0916: All boolean expressions necessary
disabled pylint R0911: All return statements are necessary
"""
# pylint: disable=E1101
# pylint: disable=R0913
# pylint: disable=R0916
# pylint: disable=R0911


def get_triangle_type(side_a=0, side_b=0, side_c=0):
    """
    Determine if the given triangle is equilateral, scalene or Isosceles

    :param side_a: line a
    :type side_a: float or int or tuple or list or dict

    :param side_b: line b
    :type side_b: float

    :param side_c: line c
    :type side_c: float

    :return: "equilateral", "isosceles", "scalene" or "invalid"
    :rtype: str
    """
    if isinstance(side_a, (tuple, list)) and len(side_a) == 3:
        side_c = side_a[2]
        side_b = side_a[1]
        side_a = side_a[0]

    if isinstance(side_a, dict) and len(side_a.keys()) == 3:
        values = []
        for value in side_a.values():
            values.append(value)
        side_a = values[0]
        side_b = values[1]
        side_c = values[2]

    if not (isinstance(side_a, (int, float)) and isinstance(side_b, (int, float)) and
            isinstance(side_c, (int, float))):
        return "invalid"

    if side_a <= 0 or side_b <= 0 or side_c <= 0:
        return "invalid"

    if side_a == side_b and side_b == side_c:
        return "equilateral"

    elif side_a == side_b or side_a == side_c or side_b == side_c:
        return "isosceles"
    else:
        return "scalene"


def get_quadrilateral_type(side_a=0, side_b=0, side_c=0, side_d=0, alpha=0, beta=0,
                           theta=0, gamma=0):
    """
    Determine type of given quadrilateral

    :param a, b, c, side_d: lines
    :type side_a: float or int or tuple or list or dict

    :param alpha, beta, theta, gamma: angles
    :type side_b: float or int


    :return: type of quadrilateral
    :rtype: str
    """

    if isinstance(side_a, (tuple, list)) and len(side_a) == 8:
        gamma = side_a[7]
        theta = side_a[6]
        beta = side_a[5]
        alpha = side_a[4]
        side_d = side_a[3]
        side_c = side_a[2]
        side_b = side_a[1]
        side_a = side_a[0]

    if isinstance(side_a, dict) and len(side_a.keys()) == 8:
        values = []
        for value in side_a.values():
            values.append(value)
        side_a = values[0]
        side_b = values[1]
        side_c = values[2]
        side_d = values[3]
        alpha = values[4]
        beta = values[5]
        theta = values[6]
        gamma = values[7]

    if not (isinstance(side_a, (int, float)) and isinstance(side_b, (int, float)) and
            isinstance(side_c, (int, float)) and isinstance(side_d, (int, float)) and
            isinstance(alpha, (int, float)) and isinstance(beta, (int, float)) and
            isinstance(theta, (int, float)) and isinstance(gamma, (int, float))):
        return "invalid"

    if side_a <= 0 or side_b <= 0 or side_c <= 0 or side_d <= 0 or alpha <= 0 or beta <= 0 or \
       theta <= 0 or gamma <= 0:
        return "invalid"

    if side_a == side_b and side_b == side_c and side_c == side_d and alpha == 90 and\
       alpha == beta and beta == theta and \
       theta == gamma:
        return "square"

    elif alpha == 90 and alpha == beta and beta == theta:
        return "rectangle"

    elif side_a == side_b and side_b == side_c and side_c == side_d and \
         alpha + beta + theta + gamma == 360:
        return "rhombus"

    elif alpha + beta + theta + gamma > 360:
        return "disconnected"

    else:
        return "unknown quadrilateral"
