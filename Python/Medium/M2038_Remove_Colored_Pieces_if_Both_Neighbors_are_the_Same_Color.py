class Solution:
    def winnerOfGame(self, colors: str) -> bool:
        n = len(colors)

        alice_moves = 0
        bob_moves = 0
        for i in range(1, n - 1):
            if colors[i - 1] != colors[i] or colors[i] != colors[i + 1]:
                continue

            if colors[i] == 'A':
                alice_moves += 1
            else:
                bob_moves += 1
        
        return alice_moves > bob_moves
