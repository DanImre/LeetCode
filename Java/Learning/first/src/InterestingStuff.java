public class InterestingStuff {
    public static void main(String[] args) {
        String s1 = "hello";
        String s2 = "hello"; // points to the same "hello" in the heap
//        s2 += "1"; // This is considered reassigning, wouldn't change s1 value

        System.out.printf("%s %s%n", s1, s2);

        char[] chars = {' ', 'h', 'e', 'l', 'l', 'o', ' '};
        String s3 = new String(chars);
        System.out.println(s3.trim());
        System.out.println(String.join(" || ", new String[]{s1,s2,s3}));

        // String.replace
        // instance.toLower/toUpper/ect.
        // instance.indexOf

        int number = 10;
        switch (number) {
            case 10: // Yellow because it knows that 10 will be printed no matter what, would delete the whole switch
                System.out.println("10");
                break;
            case 20:
                System.out.println("20");
                break;
            default:
                break;
        }
    }
}
