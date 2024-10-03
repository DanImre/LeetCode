import java.util.HashMap;
import java.util.List;

public class Variable {
    static int StaticNumberVariable = 10;
    public int PublicInstanceVariable = 100;
    public final int PrivateInstanceVariableReadonlyNumber = 1000;
    public static void main(String[] args) {
        // COMMENT WITH ctrl + '/' on numpad or block comment with ctrl + shift + '/' on numpad

        // Reformat code with CTRL + ALT + SHIFT + L

//        int localVariableNumber = 10000;

        // 'sout' is the shortcut for println
//        System.out.println(Math.pow(localVariableNumber, 2));

//        boolean boolType = false;
        // Number types: short, float, double, int, long
//        System.out.println(boolType);

        // Works the same as c#
//        System.out.println(5/9);
//        System.out.println(5/9.0);

        System.out.println(FahrenheitToCelsius(212)); // Should output 100.0

        HashMap<String,Integer> yearsANdDays = MinutesToYearsAndDays(3456789); // Should output <"Years", 6> and <"Days", 210>
        System.out.println(yearsANdDays.get("Years") + " years and " + yearsANdDays.get("Days") + " days");

        System.out.println(BMICalculator(452, 72)); //Should output ~61.3

        System.out.println(DigitSeparator(123456));

        WriteEverythingAboutTwoNumbers(25,5);
    }

    // Task one
    public static double FahrenheitToCelsius(double fahrenheit){
        return (fahrenheit-32)*5/9;
    }

    // Task two
    public static HashMap<String, Integer> MinutesToYearsAndDays(int minutes){
        HashMap<String,Integer> solution = new HashMap<>();
        solution.put("Years",minutes / (60*24*365));
        solution.put("Days", (minutes % (60*24*365)) / (60*24));
        return solution;
    }

    // Task three
    public static double BMICalculator(double weightInPounds, double heightInInches){
        return weightInPounds / Math.pow(heightInInches, 2) * 703;
    }

    // Task four
    public static List<Integer> DigitSeparator(int number){
        return  Integer.toString(number).chars().mapToObj(kk -> kk - '0' /*Integer.parseInt(String.valueOf(kk))*/).toList();
    }

    // Task five
    public static void WriteEverythingAboutTwoNumbers(double number1, double number2){
        System.out.printf("Sum: %s%n", number1 + number2);
        System.out.printf("Difference: %s%n", number1 - number2);
        System.out.printf("Product: %s%n", number1 * number2);
        System.out.printf("Average: %s%n", (number1 + number2) / 2.0);
        System.out.printf("Distance: %s%n", Math.abs(number1 - number2));
        System.out.printf("Maximum: %s%n", Math.max(number1, number2));
        System.out.printf("Minimum: %s%n", Math.min(number1, number2));
    }
}
