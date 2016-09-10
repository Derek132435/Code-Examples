%% File		: geom.erl
%% Author	: Derek Edwards
%% Purpose	: Geometry Server
-module(geom).
-export([start/0, stop/0, execute/1]).
-export([init/0]).

start() -> spawn(geom, init, []).

init() ->
	io:format("Starting...~n"),
	register(geom, self()),
	loop().
	
stop() ->
	geom ! stop.

execute(X) ->
	geom ! {request, self(), X},
	receive
		{reply, Reply} ->
			Reply
	end.

loop() ->
	receive
		{request, From, {area,square,X}} ->
			From ! {reply, {io:format("The area of the square is ~p~n", [X*X])}},
			loop();
		{request, From, {area,rectangle,X,Y}} ->
			From ! {reply, {io:format("The area of the rectangle is ~p~n", [X*Y])}},
			loop();
		{request, From, {area,circle,X}} ->
			From ! {reply, {io:format("The area of the circle is ~p~n", [math:pi()*X*X])}},
			loop();
		{request, From, {helloworld}} ->
			From ! {reply, {io:format("Hello World! ~n")}},
			loop();
		{request, From, {Other}} ->
			From ! {reply, {io:format("Error Bad Input: ~p~n", [Other])}},
			loop();
		stop ->
			io:format("Terminating...~n")
	end.