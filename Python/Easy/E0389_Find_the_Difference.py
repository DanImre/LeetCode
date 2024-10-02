class Solution:
    def findTheDifference(self, s: str, t: str) -> str:
        solution = 0
        for i in s + t:
            solution ^= ord(i)
        
        return chr(solution)