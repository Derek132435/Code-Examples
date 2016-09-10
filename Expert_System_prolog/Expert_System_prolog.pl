
/** 
 * Derek Edwards
 * Simple Expert System for CSET program
 * See example_queries.txt
 * 7/20/16
 */

course(
	humanities_elective1,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(summer),
	year(junior)
	).

course(
	humanities_elective2,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(winter),
	year(senior)
	).

course(
	humanities_elective3,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(spring),
	year(senior)
	).

course(
	tech_elective1,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(fall),
	year(senior)
	).

course(
	tech_elective2,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(winter),
	year(senior)
	).

course(
	tech_elective3,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(spring),
	year(senior)
	).

course(
	social_science_elective1,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(winter),
	year(senior)
	).

course(
	social_science_elective2,
	'N/A',
	required(no),
	credits(3),
	_,
	offered(spring),
	year(senior)
	).

course(
	bus304,
	'Engineering Management',
	required(yes),
	credits(3),
	wri227,
	offered(fall),
	year(sophomore)
	).

course(
	mgt345,
	'Engineering Economics',
	required(yes),
	credits(3),
	_,
	offered(fall),
	year(senior)
	).

course(
	mth111,
	'College Algebra',
	required(yes),
	credits(4),
	_,
	offered(winter),
	year(freshman)
	).

course(
	mth112,
	'Trigonometry',
	required(yes),
	credits(4),
	mth111,
	offered(spring),
	year(freshman)
	).

course(
	mth251,
	'Differential Calculus',
	required(yes),
	credits(4),
	mth112,
	offered(fall),
	year(sophomore)
	).

course(
	mth252,
	'Integral Calculus',
	required(yes),
	credits(4),
	mth251,
	offered(winter),
	year(sophomore)
	).

course(
	mth254n,
	'Vector Calculus',
	required(yes),
	credits(4),
	mth252,
	offered(spring),
	year(sophomore)
	).

course(
	mth327,
	'Discrete Math',
	required(yes),
	credits(4),
	mth252,
	offered(summer),
	year(sophomore)
	).

course(
	mth465,
	'Mathematical Statistics',
	required(yes),
	credits(4),
	mth254n,
	offered(summer),
	year(junior)
	).

course(
	phy221,
	'General Physics with Calculus I',
	required(yes),
	credits(4),
	mth327,
	offered(fall),
	year(junior)
	).

course(
	phy222,
	'General Physics with Calculus II',
	required(yes),
	credits(4),
	phy221,
	offered(winter),
	year(junior)
	).

course(
	phy223,
	'General Physics with Calculus III',
	required(yes),
	credits(4),
	phy222,
	offered(spring),
	year(junior)
	).

course(
	psy201,
	'Psychology',
	required(yes),
	credits(3),
	_,
	offered(spring),
	year(freshman)
	).

course(
	hist452,
	'Globalization and PNW',
	required(yes),
	credits(3),
	wri122,
	offered(spring),
	year(sophomore)
	).

course(
	wri121,
	'English Composition',
	required(yes),
	credits(3),
	_,
	offered(fall),
	year(freshman)
	).

course(
	wri122,
	'English Composition II',
	required(yes),
	credits(3),
	wri121,
	offered(winter),
	year(freshman)
	).

course(
	wri227,
	'Technical Writing',
	required(yes),
	credits(3),
	wri122,
	offered(summer),
	year(sophomore)
	).

course(
	wri350,
	'Document Development',
	required(yes),
	credits(3),
	wri227,
	offered(winter),
	year(junior)
	).

course(
	spe111,
	'Fundementals of Speech',
	required(yes),
	credits(3),
	_,
	offered(summer),
	year(freshman)
	).

course(
	spe321,
	'Group Communications',
	required(yes),
	credits(3),
	spe111,
	offered(winter),
	year(sophomore)
	).

course(
	cst102,
	'Intro to Computer Systems',
	required(yes),
	credits(3),
	_,
	offered(fall),
	year(freshman)
	).

course(
	cst105,
	'Intro to Computer Systems II',
	required(yes),
	credits(1),
	cst102,
	offered(summer),
	year(junior)
	).

course(
	cst116,
	'C++ programming I',
	required(yes),
	credits(4),
	_,
	offered(fall),
	year(freshman)
	).

course(
	cst126,
	'C++ programming II',
	required(yes),
	credits(4),
	cst116,
	offered(winter),
	year(freshman)
	).

course(
	cst130,
	'Computer Organization',
	required(yes),
	credits(3),
	cst162,
	offered(winter),
	year(freshman)
	).

course(
	cst131,
	'Computer Architecture',
	required(yes),
	credits(3),
	cst130,
	offered(spring),
	year(freshman)
	).

course(
	cst136,
	'Object Oriented Programming in C++',
	required(yes),
	credits(4),
	cst126,
	offered(spring),
	year(freshman)
	).

course(
	cst162,
	'Introduction to Digital Logic',
	required(yes),
	credits(4),
	_,
	offered(fall),
	year(freshman)
	).

course(
	cst211,
	'Data Structures',
	required(yes),
	credits(4),
	cst136,
	offered(fall),
	year(sophomore)
	).

course(
	cst223,
	'Concepts of Programming Languages',
	required(yes),
	credits(3),
	cst126,
	offered(spring),
	year(sophomore)
	).

course(
	cst229,
	'Grammars',
	required(yes),
	credits(3),
	cst211,
	offered(fall),
	year(junior)
	).


course(
	cst236,
	'Software Testing',
	required(yes),
	credits(4),
	cst136,
	offered(winter),
	year(sophomore)
	).

course(
	cst238,
	'GUI Programming',
	required(yes),
	credits(4),
	cst211,
	offered(winter),
	year(sophomore)
	).

course(
	cst240,
	'UNIX',
	required(yes),
	credits(3),
	cst126,
	offered(spring),
	year(sophomore)
	).

course(
	cst250,
	'Assembly Language',
	required(yes),
	credits(4),
	cst130,
	offered(summer),
	year(freshman)
	).

course(
	cst276,
	'Design Patterns',
	required(yes),
	credits(4),
	cst136,
	offered(fall),
	year(sophomore)
	).

course(
	cst316,
	'Software Process Management',
	required(yes),
	credits(4),
	cst211,
	offered(fall),
	year(junior)
	).

course(
	cst320,
	'Compiler Methods',
	required(yes),
	credits(4),
	cst229,
	offered(winter),
	year(junior)
	).

course(
	cst324,
	'Database System and Design',
	required(yes),
	credits(4),
	cst211,
	offered(fall),
	year(junior)
	).

course(
	cst326,
	'Software Design I',
	required(yes),
	credits(4),
	cst276,
	offered(winter),
	year(junior)
	).

course(
	cst334,
	'Project Proposal',
	required(yes),
	credits(1),
	cst336,
	offered(spring),
	year(junior)
	).

course(
	cst336,
	'Software Design II',
	required(yes),
	credits(4),
	cst236,
	offered(spring),
	year(junior)
	).

course(
	cst352,
	'Operating Systems',
	required(yes),
	credits(4),
	cst211,
	offered(spring),
	year(junior)
	).

course(
	cst412,
	'Senior Project I',
	required(yes),
	credits(3),
	cst334,
	offered(fall),
	year(senior)
	).

course(
	cst415,
	'Computer Networks',
	required(yes),
	credits(4),
	cst336,
	offered(fall),
	year(senior)
	).

course(
	cst422,
	'Senior Project II',
	required(yes),
	credits(3),
	cst412,
	offered(winter),
	year(senior)
	).

course(
	cst432,
	'Senior Project III',
	required(yes),
	credits(2),
	cst422,
	offered(spring),
	year(senior)
	).

name(Name, Class) :-
	course(Class, Name, _, _, _, _, _).

required(Required, Class, Name) :-
	course(Class, Name, Required, _, _, _, _).

credits(Credits, Class, Name) :-
	course(Class, Name, _, Credits, _, _, _).

prerequisites(Prerequisites, Class, Name) :-
	course(Class, Name, _, _, Prerequisites, _, _).

offered(Offered, Class, Name) :-
	course(Class, Name, _, _, _, Offered, _).

year(Year, Class, Name) :-
	course(Class, Name, _, _, _, _, Year).

credits_per_term_to_graduate(Credits) :-
	Total is((186 // Credits) // 4),
	write('It will take about '), write(Total), write(' years to graduate.'), nl.
 
ascend(X, Y) :- course(X, _, _, _, Y, _, _).
 
ascend(X, Y) :- course(X, _, _, _, Z, _, _),
				ascend(Z, Y).
 
count_courses_level(Total, X) :-
	aggregate_all(count, course(_, _, _, _, _, _, year(X)), Total).

count_courses_offered(Total, X) :-
	aggregate_all(count, course(_, _, _, _, _, offered(X), _), Total).

count_courses_required(Total, X) :-
	aggregate_all(count, course(_, _, required(X), _, _, _, _), Total).

count_courses(Total) :-
	aggregate_all(count, course(_, _, _, _, _, _, _), Total).

count_total_credits(Total, X) :-
    aggregate_all(sum(X), course(_, _, _, credits(X), _, _, _), Total).