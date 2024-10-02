class Solution:
    def minCostClimbingStairsFirst(self, cost: list[int]) -> int:
        dp = []
        dp.append(cost[-2])
        dp.append(cost[-1])

        for item in range(len(cost) - 3, -1, -1):
            dp.insert(0, cost[item] + min(dp[0], dp[1]))

        return min(dp[0], dp[1])
    # better

    def minCostClimbingStairs(self, cost: list[int]) -> int:
        first = cost[-2]
        second = cost[-1]

        for item in range(len(cost) - 3, -1, -1):
            first, second = cost[item] + min(first, second), first

        return min(first, second)
