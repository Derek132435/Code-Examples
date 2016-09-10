%% File		: Erlang_Fun.erl
%% Author	: Derek Edwards
%% Purpose	: Factorials, Collatz, and fibonacci encoder
-module(hw4).
-export([factorial/1]).
-export([collatz/1]).
-export([fib/1]).
-export([fib_enc/1]).
-export([fib_enc_helper/3]).

factorial(0) -> 1;
factorial(N) -> N * factorial(N-1).

collatz(1) -> 1;
collatz(N) ->
	if
		N rem 2 == 0 ->
			1 + collatz(N div 2);
		N rem 2 >= 1 ->
			1 + collatz(3 * N + 1)
	end.

fib(N) -> fib_iter(N, 0, 1).

fib_iter(0, Result,_Next) -> Result;
fib_iter(Iter, Result, Next) when Iter > 0 ->
fib_iter(Iter-1, Next, Result+Next).

fib_enc(N) -> fib_enc_helper(N, 0, 0).

fib_enc_helper(N, I, Fibo) ->
		if
			Fibo > N ->
				New_fib = fib(I-1),
				New_total = N - New_fib,
				io:format("~p = ~p~n", [I-1, New_fib]),
				fib_enc_helper(New_total, 0, 0);
			Fibo == N ->
				io:format("~p = ~p~n", [I, Fibo]);
			Fibo < N ->
				fib_enc_helper(N, I+1, (fib(I+1)));
			true ->
				io:format("Error")
		end.
