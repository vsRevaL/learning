# Recursion 

## String Reversal

```java
public class Solution{
    public static void main(String[] args){
        System.out.println(reverseString("alma")); // amla
    }
     
    public static String reverseString(String input){
        if(input.equals("")){
            return "";
        }
        
        return reverseString(input.substring(1)) + input.charAt(0);
    }
}
```

## isPalindrome

```java
public class Solution{
    public static void main(String[] args){
        System.out.println(isPalindrome("kayak")); // TRUE
    }

    public static boolean isPalindrome(String input){

        if(input.length() == 1 || input.length() == 0){
            return true;
        }

        if(input.charAt(0) == input.charAt( input.length() - 1 )){
            return isPalindrome( input.substring(1, input.length() - 1 ));
        }
        else{
            return false;
        }
    }
}
```

## Decimal to Binary

```java
public class Solution{
    public static void main(String[] args){

        System.out.println(findBinary(233,"")); // "11101001"
    }

    public static String findBinary(int decimal, String result){

        if(decimal == 0){
            return result;
        }

        result = decimal % 2 + result;
        return findBinary(decimal / 2, result);
    }
}
```

## Sum of Natural Numbers

```java
public class Solution{
    public static void main(String[] args){
        System.out.println(sumOfNumbers(10)); // 55
    }

    public static int sumOfNumbers(int n){
        return n == 0 ? n : n + sumOfNumbers(n-1);
    }
}
```

## Binary Search

```java
public class Solution{
    public static void main(String[] args) {
        int[] A = new int[]{-1,0,1,2,3,4,7,9,10,20};
        System.out.println(binarySearch(A, 0, A.length-1, 10)); // 8
    }

    public static int binarySearch(int[] A, int left, int right, int x){
        if(left > right){
            return -1;
        }

        int mid = (left + right) / 2;

        if(x == A[mid]){
            return mid;
        }

        if(x < A[mid]){
            return binarySearch(A, left, mid - 1, x);
        }

        return binarySearch(A, mid + 1, right, x);
    }
}
```

# Fibonacci (Non-Optimized)

```java
public class Solution{
    public static void main(String[] args) {
        System.out.println( fib(10) );
    }

    public static long fib(long n){
        if(n == 0 || n == 1){
            return n;
        }
        else{
            return fib(n-1) + fib(n-2);
        }
    }
}
```

## Fibonacci Dynamic

```java
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.HashMap;

public class Solution {
    public static void main(String[] args) {

        HashMap<Long, Long> memo = new HashMap<>();
        long n = 6;
        System.out.println(fib(n, memo));
    }

    public static long fib(long n, HashMap<Long, Long> memo){
        if(memo.containsKey(n)){
            return memo.get(n);
        }
        if(n <= 2){
            return 1;
        }
        memo.put(n, fib(n-1, memo) + fib(n-2, memo));
        return memo.get(n);
    }
}
```

## Merge Sort

```java
public class Solution{
    public static void main(String[] args) {
        int[] data = new int[]{-5, 20, 10, 3, 2, 0};
        mergeSort(data, 0, data.length-1);
        System.out.println("stop");
        for(int i=0; i<data.length-1; i++){
            System.out.println(data[i]);
        }
    }

    public static void mergeSort(int[] data, int start, int end){
        if(start < end){
            int mid = (start + end) / 2;
            mergeSort(data, start, mid);
            mergeSort(data, mid+1, end);
            merge(data, start, mid, end);
        }
    }

    public static void merge(int[] data, int start, int mid, int end){
        // build temp array to avoid modifying the original contents
        int[] temp = new int[end - start + 1];

        int i = start, j = mid + 1, k = 0;

        // While both sub-array have values, then try and merge them in sorted order
        while( i <= mid && j <= end){
            if( data[i] <= data[j]){
                temp[k++] = data[i++];
            }
            else{
                temp[k++] = data[j++];
            }
        }

        // Add the rest of the values from the lest sub-array into the result
        while(i <= mid){
            temp[k++] = data[i++];
        }
        while(j <= end){
            temp[k++] = data[j++];
        }

        for(i = start; i <= end; i++){
            data[i] = temp[i-start];
        }
    }
}
```


<br>
<br>
<br>
<br>
<br>