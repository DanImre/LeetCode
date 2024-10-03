import java.util.Scanner;

public class Input {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Input a something!");
        String s = input.nextLine();
        System.out.println("Input a type double number!");
        double d = input.nextDouble();

        System.out.printf("%s %s", s, d);
    }
}
