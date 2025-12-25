#Dream Builders C# Library

<a name="table-of-contents"></a>
## Table of Contents

> 1. [Patterns](#patterns)
> 1. [Extensions](#extensions)  
>   2.1 [Array](#extentions-array)  
>   2.2 [Bool](#extentions-bool)  
>   2.3 [Dictionary](#extentions-dictionary)  
>   2.4 [Enumerable](#extentions-enumerable)  
>   2.5 [Enumerator](#extentions-enumerator)  
>   2.6 [List](#extentions-list)  
>   2.7 [Numbers](#extentions-numbers)  
>   2.8 [Reflection](#extentions-reflection)  
>   2.9 [String](#extentions-string)  
>   2.10 [Task](#extentions-task) 
> 1. [Web](#web)  

<a name="patterns"></a>
## Patterns  

<a name="extensions"></a>
## Extensions  

<a name="extentions-array"></a>
#### Array  

| Method | Description |  
|-|-|  
| `Shuffle` | Based on the Fisher-Yates shuffle. |  
| `Swap` | Swaps two elements in the sequence. |

<details>
<summary> Shuffle </summary>

#### `public static T[] Shuffle<T>(this T[] sequence)`

Based on the Fisher-Yates shuffle.

Example:
```c#
public void foo()
{
  int sequence = {1,2,3};

  sequence.Shuffle();

  sequence.ForEach(
      number => Console.Write(number + " "));

  // Output will be one of sequences below:
  // 1 2 3 
  // 1 3 2 
  // 2 1 3 
  // 2 3 1 
  // 3 1 2 
  // 3 2 1 
}
```
</details>

<details>
<summary> Swap </summary>

#### `public static T[] Swap<T>(this T[] sequence, int indexA, int indexB)`

Swaps two elements in the sequence.

Example:
```c#
public void foo()
{
  int sequence = {1,2,3,4};
  int indexA = 1;
  int indexB = 3;

  sequence.Swap(indexA, indexB)

  sequence.ForEach(
      number => Console.Write(number + " "));

  // Output:
  // 1 4 3 2 
}
```
</details>

<a name="extentions-bool"></a>  
#### Bool  

<details>
<summary> IsOneOf </summary>

#### `public static bool IsOneOf<T>(this T item, params T[] options)`

Check if `item` is among the given collection of `options`.

Example:
```c#
public void foo()
{
  int options = {1,2,3,4};
  int item = 1;
  
  Console.WriteLine(item.IsOneOf(options))

  // Output:
  // true
}
```
</details>

<a name="extentions-dictionary"></a>  
#### Dictionary  

| Method | Description |  
|-|-|  

<a name="extentions-enumerable"></a>  
#### Enumerable  

| Method | Description |  
|-|-|  

<a name="extentions-enumerator"></a>  
#### Enumerator  

| Method | Description |  
|-|-|  

<a name="extentions-list"></a>  
#### List  

| Method | Description |  
|-|-|  

<a name="extentions-numbers"></a>  
#### Numbers  

| Method | Description |  
|-|-|  

<a name="extentions-reflection"></a>  
#### Reflection  

| Method | Description |  
|-|-|  

<a name="extentions-string"></a>  
#### String  

| Method | Description |  
|-|-|  

<a name="extentions-task"></a>  
#### Task  

| Method | Description |  
|-|-|  

<a name="web"></a>  
## Web  
