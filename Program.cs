// See https://aka.ms/new-console-template for more information
string message = "Find what is (Im a great developer)";
int firstPosition = message.IndexOf('(');// encuentra el indice del caracter base 0
int secondPosition = message.IndexOf(')'); // si es un solo caracter se puede colocar entre comillas simples
string newMessage = message[firstPosition..secondPosition];// esto equivale a tener message.subtring ()
// [..] proprociona un rango a partir de.. hasta. disitinto a substring que si se proporciona una longitud dada.

string newMessage2 = message[firstPosition..14];// ejemplo del rango, posicion 13 hasta la 14
string newMessage4 = message.Substring(firstPosition, 1);// posicion inical y se extiende una longitud. 

string newMessage1 = message[(firstPosition + 1)..secondPosition];// esto equivale a tener message.subtring ()
Console.WriteLine(firstPosition);
Console.WriteLine(secondPosition);
Console.WriteLine(newMessage);
Console.WriteLine(newMessage1);
Console.WriteLine(newMessage2);
Console.WriteLine(newMessage4);

string div = "What is inside the span <span>The butter is better than margarine.</span>";
int firstDiv = div.IndexOf("<span>");
int secondDiv = div.IndexOf("</span>");
string messageInDiv = div[firstDiv..secondDiv];
string messageInDiv1 = div[(firstDiv + 6)..secondDiv];
Console.WriteLine(messageInDiv);
Console.WriteLine(messageInDiv1);

string div1 = "What is inside the span <span>A lot of water under brigde.</span>";
const string openSpan = "<span>";
const string closeSpan = "</span>";
int firstStop = div1.IndexOf(openSpan);
int endStop = div1.IndexOf(closeSpan);

firstStop += openSpan.Length; // con esto no tengo que contar las posiciones (firstStop +6). la longitud ya esta incluida

string messagInspan = div1[firstStop..endStop];
Console.WriteLine();
Console.WriteLine(messagInspan);

//(indexofany() and lastindexof())

// ejemplo de indexofany()
// The IndexOfAny() helper method requires a char array of characters. 

char[] chars = { 'a', 'e', 'i', 'o', 'u', 'y',
                       'A', 'E', 'I', 'O', 'U', 'Y' };
String s = "The long and winding road...";
int vowel = s.IndexOfAny(chars);
vowel += 1;// el +1 es por el indice base 0
Console.WriteLine($"The first vowel in \n {s} is found at position {vowel}");

// recuperar la ultima aparicion de una subcadena
string theLast = "(what if) im (only instereded) in the last (set the parentheses)";
int onePosition = theLast.LastIndexOf('(');
int lastPosition = theLast.LastIndexOf(')');

//onePosition += 1; // es igual que agregar el +1 linea 57
string messageInParentheses = theLast[(onePosition + 1)..(lastPosition)];
Console.WriteLine(messageInParentheses);

//ejemplo de lastIndexOf(string)

string[] strSource = { "<b>This is bold text</b>", "<H1>This is large Text</H1>",
               "<b><i><font color=green>This has multiple tags</font></i></b>",
               "<b>This has <i>embedded</i> tags.</b>",
               "This line ends with a greater than symbol and should not be modified>" };

//Strip HTML start and end tags from each string if they are present.
foreach (string st in strSource)
{
    Console.WriteLine("Before: " + st);
    string item = st;

    //Use EndsWith to find a tag at the end of the line.
    if (item.Trim().EndsWith(">"))
    {
        //Locate the opening tag.
        int endTagStartPosition = item.LastIndexOf("</");

        // Remove the identified section, if it is valid.
        if (endTagStartPosition >= 0)
            item = item.Substring(0, endTagStartPosition);

        // Use StartsWith to find the opening tag.
        if (item.Trim().StartsWith("<"))
        {
            // Locate the end of opening tab.
            int openTagEndPosition = item.IndexOf(">");
            // Remove the identified section, if it is valid.
            if (openTagEndPosition >= 0)
                item = item.Substring(openTagEndPosition + 1);
        }
    }
    // Display the trimmed string.
    Console.WriteLine("After: " + item);
    Console.WriteLine();
}

// ejemplo de lastindexof(string,int32,int32)
string br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
string br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
string str = "Now is the time for all good men to come to the aid of their party.";
int start;
int at;
int count;
int end;

start = str.Length - 1;
end = start / 2 - 1;
Console.WriteLine("All occurrences of 'he' from position {0} to {1}.", start, end);
Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str);
Console.Write("The string 'he' occurs at position(s): ");

count = 0;
at = 0;
while ((start > -1) && (at > -1))
{
    count = start - end; //Count must be within the substring.
    at = str.LastIndexOf("he", start, count);
    if (at > -1)
    {
        Console.Write("{0} ", at);
        start = at - 1;
    }
}
Console.Write("{0}{0}{0}", Environment.NewLine);

// recuperar todas las instancias de subcadenas entre parentesis. 
string allwords = "(what if) im (only instereded) in the last (set the parentheses)";
while (true)
{
    int onePosition1 = allwords.IndexOf('(');
    if (onePosition1 >= 0)
    {

        int lastPosition2 = allwords.IndexOf(')');
        onePosition1 += 1;
        string messageInParentheses1 = allwords[onePosition1..lastPosition2];
        Console.WriteLine(messageInParentheses1);
        allwords = allwords[(lastPosition2 + 1)..];
    }
    else
    {
        break;
    }

}

// buscar diferentes tipos de conjuntos de simbolos
//* devolver el indicie del primer simbolo encontrado

string symbol = "Help (find) the {opening symbol}";
Console.WriteLine($"Searching THIS message: {symbol}");
char[] openSymbol = ['{', '(',];
int startPosition = 5;
int firstSymbol = symbol.IndexOfAny(openSymbol);
Console.WriteLine($"Found whitout startPosition: {symbol[firstSymbol..]}");

firstSymbol = symbol.IndexOfAny(openSymbol, startPosition);
Console.WriteLine($"Found whit startPosition {startPosition}: {symbol[firstSymbol..]}");

// encontrar el simbolo de apertura y cierre correspondiente

string foundMe = "(what if) i have [different Symbols] but every {open symbol} needs a {matching closing symbol}?";

char[] openSymbols = ['{', '(', '['];
int closingPosition = 0;
//La variable closingPosition se usa para buscar la longitud pasada al método Substring()
//y para buscar el siguiente valor firstMatch:
//Por ese motivo, la variable closingPosition se define fuera del ámbito de bucle while
// y se inicializa en 0 para la primera iteración.
while (true)
{
    int firstMatch = foundMe.IndexOfAny(openSymbols, closingPosition);
    //Console.WriteLine(firstMatch); me imprime el indice de la primera aparcion del simbolo.
    if (firstMatch == -1)
    {
        break;
    }
    else
    {
        string currentSymbol = foundMe.Substring(firstMatch, 1);// me regresa una subcadena tomando en 
        //cuenta la posicion del carcater y lo extiende una posicion mas, asi poder comparar el simbolo en el switch
        //Console.WriteLine(currentSymbol); comprueba lo de arriba. 

        char matchingCloseSymbol = ' ';

        switch (currentSymbol)
        {
            case "(":
                matchingCloseSymbol = ')';
                break;
            case "{":
                matchingCloseSymbol = '}';
                break;
            case "[":
                matchingCloseSymbol = ']';
                break;
        }
        // To find the closingPosition, use an overload of the IndexOf method to specify 
        // that the search for the matchingSymbol should start at the openingPosition in the string. 

        firstMatch += 1;// es igual que agregar el +1 en linea 283 (firstMarch+1)
        //asi solo me imprime el simbolo inicial, lo corre una posicion
        closingPosition = foundMe.IndexOf(matchingCloseSymbol, firstMatch);

        //Console.WriteLine(closingPosition); imprime la poscion del sinmbolo de cierre.

        // Finally, use the techniques you've already learned to display the sub-string:
        string inside = foundMe[firstMatch ..closingPosition];
        Console.WriteLine(inside);
    }
}






