import math

class Solution:
    def __init__(self) -> None:
        self.asd = "adasdasd"

    def largestGoodInteger(self, num: str) -> str:
        m = -1
        counter = 1
        for i in range(1, len(num)):
            if num[i] == num[i - 1]:
                counter += 1
            else:
                counter = 1
            
            if counter == 3:
                m = max(m, int(num[i]))
                if m == 9:
                    break
        
        if m == -1:
            return ""
        solution = ""

        for i in range(0,3):
            solution += str(m)

        return solution
