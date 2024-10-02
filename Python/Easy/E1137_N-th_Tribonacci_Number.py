class Solution:
    def tribonacci(self, n: int) -> int:
        if n <= 1:
            return n
        
        first = 0
        second = 1
        third = 1
        for i in range(3, n + 1):
            temp = first + second + third
            first = second
            second = third
            third = temp

        return third