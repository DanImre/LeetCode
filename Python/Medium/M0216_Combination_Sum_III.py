class Solution:
    def combinationSum3(self, k: int, n: int) -> list[list[int]]:
        self.solution = []
        self.backTrack(k, n, 1, [])
        return self.solution

    def backTrack(self, k: int, n: int, currNumber: int, list: list):
        if (k == 0 and n == 0):
            self.solution.append(list)
            return
        if (currNumber > n or k == 0 or currNumber == 10):
            return

        # with current number
        self.backTrack(k - 1, n - currNumber, currNumber + 1, list + [currNumber])

        #without current number
        self.backTrack(k, n, currNumber + 1, list)