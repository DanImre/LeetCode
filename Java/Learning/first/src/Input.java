import java.util.Scanner;

public class Input {
    public static void main(String[] args) {
/*
        Scanner input = new Scanner(System.in);
        System.out.println("Input a something!");
        String s = input.nextLine();
        System.out.println("Input a type double number!");
        double d = input.nextDouble();

        System.out.printf("%s %s", s, d);
*/
        Scanner input = new Scanner(System.in);
        int number = -1;
        do {
            System.out.println("Input a positive number!");
            if (input.hasNextInt())
                number = input.nextInt();
            else
                input.next();
        } while (number < 0);

        WriteMultiplicationTableFor(number);
    }

    public static void WriteMultiplicationTableFor(int number) {
        for (int i = 0; i <= number; i++) {
            for (int j = 0; j <= number; j++) {
                System.out.printf("%d\t", i * j);
            }
            System.out.print("\n");
        }
    }
}
