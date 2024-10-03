import java.util.ArrayList;
import java.util.List;

public class BankAccount {
    private int money = 0;
    private final List<String> transactionList = new ArrayList<>();

    public BankAccount() {
        transactionList.add("Opened a bank account without any money.");
    }

    public BankAccount(int moneyToAdd) {
        money = moneyToAdd;
        transactionList.add("Opened a bank account with %d money.".formatted(moneyToAdd));
    }

    public int GetBalance() {
        transactionList.add("Queried the balance.");
        return money;
    }

    public void Deposit(int moneyToDeposit) {
        transactionList.add("Deposited %d amount of money.".formatted(moneyToDeposit));
        money += moneyToDeposit;
    }

    public void Withdraw(int moneyToWithdraw) {
        if (moneyToWithdraw > money)
        {
            System.out.println("Can't withdraw more then is in you account!");
            transactionList.add("Tried to withdraw %d amount of money, but failed".formatted(moneyToWithdraw));
            return;
        }
        transactionList.add("Withdrawn %d amount of money.".formatted(moneyToWithdraw));
        money -= moneyToWithdraw;
    }

    public List<String> GetLogs() {
        transactionList.add("Queried the logs.");
        return new ArrayList<>(transactionList);
    }
}
