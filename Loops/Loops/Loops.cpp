// Loops.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;



int main()
{
	setlocale(LC_ALL, "rus");

	/* Циклы */
	/*
		-= Виды циклов =-
		1. for - http://cppstudio.com/post/348/
		2. while
		3. do/while
	*/

	//Вывести числа в диапазоне от 0 до 9
	for (int i = 0; i < 10; i++)
	{
		cout << i << " ";
	}
	cout << endl;

	//Вывод 50 звездочек на экран
	//cout << "**************************************************" << endl;

	for (int i = 0; i < 50; i++)
	{
		cout << "*";
	}
	cout << endl;

	//Вывод чисел в порядке убывания от 10 к 0
	for (int i = 10; i > 0; i--)
	{
		cout << i << " ";
	}
	cout << endl;



	


	system("pause");
	return 0;
}

