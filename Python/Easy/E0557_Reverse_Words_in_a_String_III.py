class Solution:
    def reverseWords(self, s: str) -> str:
        splitted = s.split(" ")

        for i in range(len(splitted)):
            splitted[i] = splitted[i][::-1]

        return " ".join(splitted)
