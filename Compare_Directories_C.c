// Derek Edwards
// 7/30/16
// C program to compare directories passed on the command line

#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <dirent.h>
#include <errno.h>
#include <sys/stat.h>
#include <string.h>

#define E_INVALIDSWITCH 100
#define E_TOOMANYPARAMS	101
#define E_TOOFEWPARAMS	102
#define E_OPENDIRFAIL	103

void usage();
void compDirectory(int R_switch, int D_switch, char * dir1, char * dir2);
void compDirNEW(int R_switch, int D_switch, char * dir1, char * dir2);

int main(int argc, char ** argv) {

	int D_switch = 0;   /* capitalize the greeting */
	int R_switch = 0;   /* clear the screen */
	char * baseDir = NULL;
	char * modDir = NULL;

	int i;
	for (i = 1; i < argc; i++) {
		if (argv[i][0] == '-') {
			if (strcmp(argv[i], "-D") == 0) {
				D_switch = 1;    /* non-zero means true*/
			}
			else if (strcmp(argv[i], "-R") == 0) {
				R_switch = 1;
			}
			else {
				fprintf(stderr, "Error: Invalid switch %s\n", argv[i]);
				usage();
				return E_INVALIDSWITCH;
			}
		}
		else {
			/* positional parameters */
			if (baseDir == NULL) {
				baseDir = argv[i];
			}
			else if (modDir == NULL) {
				modDir = argv[i];
			}
			else {
				fprintf(stderr, "Error: Too many parameters\n");
				usage();
				return E_TOOMANYPARAMS;
			}
		}
	}

	/*//check assignment of args
	if (D_switch) { printf("D_switch active\n"); }
	if (R_switch) { printf("R_switch active\n"); }
	printf("baseDir is set to: %s\nmodDir is set to: %s\n", baseDir, modDir);*/

	if ((baseDir == NULL) || (modDir == NULL)) {
		fprintf(stderr, "Error: Too few parameters\n");
		usage();
		return E_TOOFEWPARAMS;
	}
	else {
		compDirectory(R_switch,D_switch,baseDir, modDir);
		compDirNEW(R_switch,D_switch,baseDir, modDir);
	}

	return 0;
}

void usage() {
	printf("Usage:  compdir.exe [-D] [-R] <baseDir> <modDir>\n");
	printf("\t-D\tShows the differences between modified files\n");
	printf("\t-R\tSearches recursively through given directories\n");
	printf("\t<baseDir>\tFirst directory to compare\n");
	printf("\t<modDir>\tSecond directory to compare\n");
}

void compDirectory(int R_switch,int D_switch,char * dir1, char * dir2) {

	DIR * baseDir;
	DIR * modDir;
	struct dirent * baseDirInfo;

	/*try to open directories*/
	baseDir = opendir(dir1);
	if (baseDir == NULL) {
		fprintf(stderr,
		"opendir() failed for '%s', errno=%d\n",
		dir1, 
		errno);
		exit(E_OPENDIRFAIL);
	}
	modDir = opendir(dir2);
	if (modDir == NULL) {
		fprintf(stderr,
		"opendir() failed for '%s', errno=%d\n",
		dir2, 
		errno);
		exit(E_OPENDIRFAIL);
	}

	//printf("\nFirst Function: \nbaseDir is set to: %s\nmodDir is set to: %s\n", dir1, dir2);
	while((baseDirInfo = readdir(baseDir)) != NULL) {

		if (strcmp(baseDirInfo->d_name, ".") != 0 &&
			strcmp(baseDirInfo->d_name, "..") != 0)
		{
			/* build the path to the item */
			char basePath[PATH_MAX];
			char modPath[PATH_MAX];
			strcpy(basePath, dir1);
			strcat(basePath, "/");
			strcat(basePath, baseDirInfo->d_name);
			strcpy(modPath, dir2);
			strcat(modPath, "/");
			strcat(modPath, baseDirInfo->d_name);

			
			struct stat baseStatBuf;
			struct stat modStatBuf;

			/* does file exist in baseDir */
			if (stat(basePath, &baseStatBuf) == -1) {
				/* error! */
				fprintf(stderr, "stat() failed for '%s'", basePath);
			}
			else
			{
				/*is it a directory or a file?*/
				if (S_ISDIR(baseStatBuf.st_mode))
				{
					/* if recursion is enabled, then recurse!, otherwise move on */
					if(R_switch) { compDirectory(R_switch,D_switch,basePath, modPath); }
				}
				else {
					/* does file exist in modDir */
					if (stat(modPath, &modStatBuf) == -1) {
						/*file has been DELETED*/
						printf("%s : DELETED\n", basePath);
					}
					/*check the timestamps to see if modDir file is newer than baseDir file*/
					else if (modStatBuf.st_mtime > baseStatBuf.st_mtime) {
						/*yes- print mod condition*/
						printf("%s : MODIFIED\n", basePath);
						if(D_switch){
							char diffcmd[256];
							sprintf(diffcmd, "diff %s %s", basePath, modPath);
							system(diffcmd);
						}
					}
				}
			}
		}
	}
	closedir(baseDir);
	closedir(modDir);
}

void compDirNEW(int R_switch, int D_switch, char * dir1, char * dir2) {
	
	DIR * baseDir;
	DIR * modDir;
	struct dirent * modDirInfo;

	/*try to open directories*/
	baseDir = opendir(dir1);
	if (baseDir == NULL) {
		fprintf(stderr,
		"opendir() failed for '%s', errno=%d\n",
		dir1, 
		errno);
		exit(E_OPENDIRFAIL);
	}
	modDir = opendir(dir2);
	if (modDir == NULL) {
		fprintf(stderr,
		"opendir() failed for '%s', errno=%d\n",
		dir2, 
		errno);
		exit(E_OPENDIRFAIL);
	}

	/* check if file is NEW i.e. is it in modDir but not baseDir? */
	
	//printf("\nSecond Function: \nbaseDir is set to: %s\nmodDir is set to: %s\n", dir1, dir2);

	while((modDirInfo = readdir(modDir)) != NULL) {
		
		if (strcmp(modDirInfo->d_name, ".") != 0 &&
			strcmp(modDirInfo->d_name, "..") != 0)
		{
			/* build the path to the item */
			char basePath[PATH_MAX];
			char modPath[PATH_MAX];
			strcpy(modPath, dir2);
			strcat(modPath, "/");
			strcat(modPath, modDirInfo->d_name);
			strcpy(basePath, dir1);
			strcat(basePath, "/");
			strcat(basePath, modDirInfo->d_name);
			
			struct stat baseStatBuf;
			struct stat modStatBuf;

			/* does file exist in modDir */
			if (stat(modPath, &modStatBuf) == -1) {
				fprintf(stderr, "stat() failed for '%s'", modPath);
			}
			else {
				/*is it a directory or a file?*/
				if (S_ISDIR(modStatBuf.st_mode))
				{
					/* if recursion is enabled, then recurse!, otherwise move on */
					if(R_switch) { compDirNEW(R_switch,D_switch,basePath, modPath); }
				}
				else {
					/* does file exist in baseDir */
					if (stat(basePath, &baseStatBuf) == -1) {
						/*file is NEW*/
						printf("%s : NEW\n", modPath);
					}
				}
			}
		}
	}
	closedir(baseDir);
	closedir(modDir);
}