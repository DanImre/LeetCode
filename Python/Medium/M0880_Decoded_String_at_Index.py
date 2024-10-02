class Solution:
    def decodeAtIndex(self, s: str, k: int) -> str:
        length = 0
        index = 0
        while length < k:
            if s[index].isdigit():
                length *= int(s[index])
            else:
                length += 1
            index += 1

        while True:
            index -= 1
            if s[index].isdigit():
                length /= int(s[index])
                k %= length
            elif k % length == 0:
                return s[index]
            else:
                length -= 1
