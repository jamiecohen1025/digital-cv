//Author: Jamie Cohen
//Due Date: 11/15/2020
//Project 8: Wind data

#include <stdio.h>

#define FILE_WIND "wind.txt"
#define NUM_DIGITS 50

int  getMenuChoice();
int loadWindData(FILE* fp, double windSpeeds[], char windDirections[]);
void displayWindData(int DataItems, double windSpeeds[], char windDirections[]);
void calcWindStats(int DataItems, double windSpeeds[], char windDirections[], double *avgWindSpeed, char *PrevalentDirection);
int addWindData(FILE* fp,int DataItems, double windSpeeds[], char windDirections[]); 

int main()
{
	FILE* fp;
	int userchoice;
	double meanSpeed;
	char modeDirection;
	int DataItems;
	double windSpeeds[NUM_DIGITS];
	char windDirections[NUM_DIGITS];

	do
	{
		userchoice = getMenuChoice();
		
		switch (userchoice)
		{
			case 0:
				break;
				
			case 1:
				fp = fopen(FILE_WIND,"r");
				if (fp == NULL)
				{
					printf("Error in opening file\n");
				}
				else
				{
					DataItems = loadWindData(fp,windSpeeds,windDirections);
					fclose(fp);
				}
				break;
				
			case 2:
				displayWindData(DataItems,windSpeeds,windDirections);
				break;
				
			case 3:
				calcWindStats(DataItems,windSpeeds,windDirections, &meanSpeed, &modeDirection);
				printf("Wind averages %.2lf mph, mostly in the %c direction.\n", meanSpeed, modeDirection);
				break;
				
			case 4:
				fp = fopen(FILE_WIND,"a");
				if (fp == NULL)
				{
					printf("Error in opening file\n");
				}
				else
				{
					DataItems = addWindData(fp, DataItems, windSpeeds,windDirections);
					fclose(fp);
				}
				break;
				
			default:
				printf("Please enter a valid option.\n");
				break;
		}
	} while (userchoice != 0);

	return 0;
}

//---------------------------------------------------------------------------------------------------------------------------

int  getMenuChoice()
{
	int userinput;
	
	printf("**WIND DATA**\n1. Load Wind Data\n2. Display Wind Data\n3. Analyze Wind Data\n4. Add Wind Data\n0. EXIT\n");
	
	printf("Enter your choice: ");
	scanf("%d",&userinput);
	
	return userinput;
}

//---------------------------------------------------------------------------------------------------------------------------

int loadWindData(FILE* fp, double windSpeeds[], char windDirections[])
{
	int count =0;
	double windSpeed;
	char windDirection;
	
	while (fscanf(fp,"%lf %c\n", &windSpeeds[count], &windDirections[count]) == 2)
	{
		count++;
	}
	
	return count;
}

//---------------------------------------------------------------------------------------------------------------------------

void displayWindData(int DataItems, double windSpeeds[], char windDirections[])
{
	int counter = 0;
	char line = '|';
	
	printf("\nWIND DATA\n");
	
	for(int i = 0; i < 49; i++)
	{
		printf("=");
	}
	printf("\n||Item #      |    Wind Speed    |  Direction  ||\n");
	printf("||");
	for(int i = 0; i < 45; i++)
	{
		printf("=");
	}
	printf("||\n");
	
	for(int i = 0; i < DataItems; i++)
	{
		printf("||");
		for(int i = 0; i < 12; i++)
		{
			printf("-");
		}
		printf("|");
		for(int i = 0; i < 18; i++)
		{
			printf("-");
		}
		printf("|");
		for(int i = 0; i < 13; i++)
		{
			printf("-");
		}
		printf("||\n");
	printf("||%8d%5c%9.2lf%10c%3c%11c|\n", counter+1, line, windSpeeds[i],line, windDirections[i],line);
		counter++;
	}
	
	printf("||");
	for(int i = 0; i < 12; i++)
	{
		printf("-");
	}
	printf("|");
	for(int i = 0; i < 18; i++)
	{
		printf("-");
	}
	printf("|");
	for(int i = 0; i < 13; i++)
	{
		printf("-");
	}
	printf("||\n");
	for(int i = 0; i < 49; i++)
	{
		printf("=");
	}
	printf("\n");
}

//---------------------------------------------------------------------------------------------------------------------------

void calcWindStats(int DataItems, double windSpeeds[], char windDirections[], double *avgWindSpeed, char *PrevalentDirection)
{
	double sumSpeeds;
	int countDirections[4];
	countDirections[0]=0;
	countDirections[1]=0;
	countDirections[2]=0;
	countDirections[3]=0;
	int maxcount =0, intermediatecount = 0;
	
	for(int i = 0; i < DataItems; i++)
	{
		sumSpeeds += windSpeeds[i];
		
		switch (windDirections[i])
		{
			case 'N':
				countDirections[0]++;
				break;
			case 'S':
				countDirections[1]++;
				break;
			case 'E':
				countDirections[2]++;
				break;
			case 'W':
				countDirections[3]++;
				break;			
		}
	}
	
	*avgWindSpeed = sumSpeeds/DataItems;
	
	for (int j = 0; j<3; j++)
	{
		if (countDirections[j] > intermediatecount)
		{
			intermediatecount = countDirections[j];
			maxcount = j;
		}
	}
	switch(maxcount)
	{
		case 0:
			*PrevalentDirection = 'N';
			break;
		case 1:
			*PrevalentDirection = 'S';
			break;
		case 2:
			*PrevalentDirection = 'E';
			break;
		case 3:
			*PrevalentDirection = 'W';
			break;
	}
}

//----------------------------------------------------------------------------------------------------

int addWindData(FILE* fp,int DataItems, double windSpeeds[], char windDirections[])
{
	int userAddInput;

	printf("How many data items would you like to add? ");
	scanf("%d", &userAddInput);
					
	for(int i = 0; i <userAddInput; i++)
	{
		DataItems++;
		printf("Wind speed?: ");
		scanf("%lf", &windSpeeds[DataItems]);
		printf("Wind direction: ");
		scanf("\n%c", &windDirections[DataItems]);
		fprintf(fp,"%lf %c\n",windSpeeds[DataItems], windDirections[DataItems]);
	}

	return DataItems;
}

