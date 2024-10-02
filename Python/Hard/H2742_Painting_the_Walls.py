class Solution:
    def paintWalls(self, cost: list[int], time: list[int]) -> int:
        self.n = len(cost)
        self.dp = [[0 for j in range(self.n + 1)] for i in range(self.n)]  # [n][n + 1]

        return self.recursiveSolution(0, self.n, cost, time)

    def recursiveSolution(self, currIndex, remainingWalls, cost, time):
        if remainingWalls <= 0:
            return 0
        if currIndex == self.n:
            return 1e9

        if self.dp[currIndex][remainingWalls] == 0:
            self.dp[currIndex][remainingWalls] = min(
                cost[currIndex] + self.recursiveSolution(currIndex + 1, remainingWalls - 1 - time[currIndex], cost, time),
                self.recursiveSolution(currIndex + 1, remainingWalls, cost, time),
            )

        return self.dp[currIndex][remainingWalls]
