class Solution:
    def numOfArrays(self, n: int, m: int, k: int) -> int:
        self.dp = []
        for i in range(0, n):
            self.dp.append([])
            for j in range(0, m + 1):
                self.dp[i].append([])
                for l in range(0, k + 1):
                    self.dp[i][j].append(-1)

        self.n = n
        self.m = m
        self.mod = int(1e9 + 7)

        return self.recursiveSolution(0, 0, k)

    def recursiveSolution(self, index: int, max_so_far: int, remain: int):
        if index == self.n:
            if remain == 0:
                return 1
            return 0

        if remain < 0:
            return 0

        if self.dp[index][max_so_far][remain] != -1:
            return self.dp[index][max_so_far][remain]
        solution = 0
        for i in range(1, max_so_far + 1):
            solution = (solution + self.recursiveSolution(index + 1, max_so_far, remain)) % self.mod
        
        for i in range(max_so_far + 1, self.m + 1):
            solution = (solution + self.recursiveSolution(index + 1, i, remain - 1)) % self.mod
        
        self.dp[index][max_so_far][remain] = solution
        return solution
