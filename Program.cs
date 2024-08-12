/*
Program that takes in a string sentence as input and then translates each word appropriately
*/

//variable declaration
string userInput;
bool runProgram = true;

//Main loop for the program, keeps the program running endlessly while runProgram is equal to true
do {
    System.Console.WriteLine("Hello! Please enter a word: ");
    userInput = Console.ReadLine();

    if(userInput.Trim() == ""){
        System.Console.WriteLine("Input cannot be empty. Please try again.");
        
    } 
    else{
        string finalSentence = "";
    
        string[] words = userInput.Split(' ');

        /*if (words = " "){
            System.Console.WriteLine("Please enter text");
        }*/

         //The word word is used so many times in this loop that the word word doesn't look like a real word anymore

        /*
        For each loop that takes the broken up sentence input "words", and for each word, converts it to PigLatin
        and then adds the converted word into a new variable oneWord
        */
        foreach (string word in words){
            string segment = ""; 
            char currentLetter = word[0];

            bool isVowel = "aeiouAEIOU".Contains(currentLetter);
            //Checks if there is a symbol in the word
            bool hasSymbol = word.Any(c => "\"|#$%&/()\\=»«@£§€{}-;'<>_".Contains(c)); // The backslash "\\" and "\"" prevents it from messing up the line

            //If the first letter is a vowel, and the word does not have a symbol, then translate
            if(isVowel && !hasSymbol) {
                segment = word + "way ";
            } 
            else{
                segment = convertString(word) + " ";
            }
            finalSentence += segment;
         }

         System.Console.WriteLine(finalSentence.Trim());

        runProgram = QuestionUser(runProgram);
    }
    
} while (runProgram);


 //Method that asks user if they would like to continue
static bool QuestionUser(bool answer){
    while(true){
        System.Console.WriteLine("Would you like to continue? Please enter yes or no");
        string choice = Console.ReadLine();
        if (choice.ToLower().Trim() == "yes"){
            answer = true;
            break;
        } 
        else if (choice.ToLower().Trim() == "no"){
            answer = false;
            break;
        } 
        else {
            System.Console.WriteLine("Invalid response");
        }
    }
    return answer;
}

//Method that does the Pig Latin string conversion
static string convertString(string word){
    string vowels = "aeiouAEIOU";
    //bool safe = false;

    //For each character in the word, check if it contains a special charcter or number. If it does, return the word as is
    foreach (char c in word){
        if ("\\|#$%&/()=»«@£§€{}\"-;'<>_,".Contains(c)){
            return word;
        }
        if (Char.IsDigit(c)){
            return word;
        }
    }

    /*
    Loop that follows the rules of Pig Latin. Goes through to the first vowel 
    of the word, then takes the letters before and after, puts them into two strings,
    reverses them, and adds "ay"
    */
    for (int i = 0; i < word.Length; i++){
        if (vowels.Contains(word[i])){
            string beforeVowel = word.Substring(0, i);
            string afterVowel = word.Substring(i);

            return afterVowel + beforeVowel + "ay";
        }
    }
    return word + "ay";
}
