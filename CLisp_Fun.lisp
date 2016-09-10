;;FILE		:CLisp_Fun.lisp
;;Author	:Derek Edwards (C) 2016. All rights reserved
;;Purpose	:Factorial and fibonacci encoder

#| ;2a)
(defun factorial (n)
	(if (= n 0)
		1
		(* n (factorial (- n 1)))))

(format t "~%-----------------------~%")		
(loop for i from 0 to 9
	do (format t "~D! = ~D~%" i (factorial i)))
(format t "-----------------------")
|#

#| ;2b)
(defun factorial (n)
	(if (= n 0)
		1
		(* n (factorial (- n 1)))))
		
(defvar *firstn* (read))

(defun main(*firstn*)
	(format t "~%-----------------------~%")
	(dotimes (i *firstn*)
	do (format t "~D! = ~D~%" i (factorial i)))
	(format t "-----------------------")
	(values))

(main *firstn*)
|#

(defun fib (n)
  (check-type n (integer 0 *))
  (do ((i n (1- i))
       (f1 0 f2)
       (f2 1 (+ f1 f2)))
      ((= i 0) f1)))

(defun difference (num1 num2)
(return-from difference(- num1 num2))
)

(defun fib_encoder (n)
	(format t "Fibonacci Endcoder: (~D)~%" n)
	(defvar i 0)
	(loop
		(setq fibo (fib i))
		(cond ((> fibo n)
				(setf i (- i 1))
				(setf fibo (fib i))
				(setf n (- n fibo))
				(format t "Index ~D = ~D +~%" i fibo)
				(setf i 0))
			((= fibo n)
				(setf n 0)
				(format t "Index ~D = ~D ~%" i fibo))
			(t (setf i (+ i 1))))
		(when (= n 0)(return)))
	(values))

(defun main(n)
	(format t "~%-----------------------~%")
	(format t "Student ID Encoded - ~%~%")
	(format t "-----------------------" (fib_encoder n))
	(format t "~%-----------------------~%")
	(format t "Student ID Encoded Squared - ~%~%")
	(format t "-----------------------" (fib_encoder (* n n)))
	(format t "~%-----------------------~%")
	(format t "Student ID Encoded Cubed - ~%~%")
	(format t "-----------------------" (fib_encoder (* n (* n n))))
	(values))

(main 918228812)