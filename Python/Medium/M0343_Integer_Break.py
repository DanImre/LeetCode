class Solution:
    def integerBreak(self, n: int) -> int:
        if n < 4:
            return n - 1
        
        solution = 1
        while n > 4:
            solution *= 3
            n -= 3
        
        return solution * n