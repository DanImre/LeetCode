import java.util.Scanner;

public class BankingApplication {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        BankAccount account = new BankAccount(1000);

        System.out.println("Welcome to you bank account! Press any key to continue.");
        input.next();

        boolean keepRunning = true;
        while (keepRunning) {
            int option = -1;
            do {
                // Clears screen
                System.out.print("\033[H\033[2J");
                System.out.flush();

                System.out.println("Menü:");
                System.out.println("1) Make a deposit!");
                System.out.println("2) Withdraw your money!");
                System.out.println("3) Get previous transactions!");
                System.out.println("4) Exit the application!");

                System.out.println("\n Account balance:" + account.GetBalance());
                if (input.hasNextInt())
                    option = input.nextInt();
                else
                    input.next();
            } while (option < 0 || option > 4);

            switch (option) {
                case 1:
                    System.out.print("Type in the amount: ");
                    account.Deposit(input.nextInt());
                    break;
                case 2:
                    System.out.print("Type in the amount: ");
                    account.Withdraw(input.nextInt());
                    break;
                case 3:
                    System.out.print(account.GetLogs() + "\n");
                    break;
                default: // 4
                    System.out.println("Goodbye!");
                    keepRunning = false;
                    break;
            }
        }
    }
}

