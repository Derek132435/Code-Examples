//Derek Edwards
//8/9/16
//Calculator: combines BASH and C

#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>


#define E_TOOMANYARGS 100
#define E_TOOMANYOPS 101
#define E_INVALIDOPERATOR 102
#define E_NOTANUMBER 103
#define E_TOOFEWARGS 104

void usage();
int add();
int multiply();
int divide();
int subtract();
int debug = 1;

int main(int argc,char ** argv)
{
	int A_switch = 0;	//addition switch
	int S_switch = 0;	//subtraction switch
	int M_switch = 0;	//multiplication switch
	int D_switch = 0;	//Division switch
	char operator = 0;	//Conditional for operator
	int userinput1 = 0;	//conditional for userinput1
	int userinput2 = 0;	//conditional for userinput2
	
	int i;
	for (i = 1; i < argc; i++) {
		//is it an operator?	
		if(!strcmp(argv[i], "+")) {
			//if operator is not already set
			if(!operator) {
				A_switch = 1;
				operator = 1;
			}
			else {
				fprintf(stderr, "Error: Too Many Operators");
				usage();
				return E_TOOMANYOPS;
			}
		}
		else if(!strcmp(argv[i], "-")) {
			//if operator is not already set
			if(!operator) {
				S_switch = 1;
				operator = 1;
			}
			else {
				fprintf(stderr, "Error: Too Many Operators");
				usage();
				return E_TOOMANYOPS;
			}
		}
		else if(!strcmp(argv[i], "*")) {
			//if operator is not already set
			if(!operator) {
				M_switch = 1;
				operator = 1;
			}
			else {
				fprintf(stderr, "Error: Too Many Operators");
				usage();
				return E_TOOMANYOPS;
			}
		}
		else if(!strcmp(argv[i], "/")) {
			//if operator is not already set
			if(!operator) {
				D_switch = 1;
				operator = 1;
			}
			else {
				fprintf(stderr, "Error: Too Many Operators");
				usage();
				return E_TOOMANYOPS;
			}
		}
		//is it a number?
		else if(isdigit(argv[i][0])) { 
			//if first is not set
			if(!userinput1) { 
				sscanf(argv[i], "%d", &userinput1);
			}	
			else if(!userinput2) { 
				sscanf(argv[i], "%d", &userinput2);
			}
			else {
				fprintf(stderr, "Error: Too many args");
				return E_TOOMANYARGS;
			}
		}
		//not a number and not a flag
		else {
			fprintf(stderr, "Error: Not a number");
			usage();
			return E_NOTANUMBER;
		}
			
	}
	
	if((!userinput1) || (!userinput2) || (!operator)) {
		fprintf(stderr, "Error: Too few arguments\n %d %d %s", userinput1, userinput2, operator);
		usage();
		return E_TOOFEWARGS;
	}
	
	if(A_switch) {
		printf("%d", add(userinput1,userinput2));
		return 0;
	}
	else if(S_switch) {
		printf("%d", subtract(userinput1,userinput2));
		return 0;
	}
	else if(D_switch) {
		printf("%d", divide(userinput1,userinput2));
		return 0;
	}
	else if(M_switch) {
		printf("%d", multiply(userinput1,userinput2));
		return 0;
	}
	else {
		fprintf(stderr, "Error: Unknown Error");
		return E_TOOMANYARGS;
	}
}
	
int add(int userinput1, int userinput2) {
	return (userinput1 + userinput2);
}

int subtract( int userinput1, int userinput2) {
	return (userinput1 - userinput2);
}

int multiply( int userinput1, int userinput2) {
	return (userinput1 * userinput2);
}
int divide( int userinput1, int userinput2) {
	return (userinput1 / userinput2);
}

void usage() {
	printf("Usage: CCalc <operator> <int1> <int2>\n");
	printf("\t<operator>\t Can be 1 of 4 operators: '-' '+' '/' '*'\n");
    	printf("\t<int1>\tFirst operand\n");
    	printf("\t<int2>\tSecond operand\n");
}


