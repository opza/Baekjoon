const int BOX1 = 3;
const int BOX2 = 5;

for (int i = 3; i < 100; i++)
{
    Console.WriteLine($"{i} : {GetBoxCount(i)}");
}
//var kg = int.Parse(Console.ReadLine());
//Console.WriteLine(GetBoxCount(kg));

int GetBoxCount(int kg) => CalMinBoxCount(kg, 0);

int CalMinBoxCount(int kg, int count)
{
    if (kg == 0)
        return count;

    if (kg < 0)
        return -1;

    var count1 = -1;
    var count2 = -1;

    if (kg % BOX1 != 0)
        count1 = CalMinBoxCount(kg - BOX2, count + 1);
    else
        count1 = count + kg / BOX1;

    if (kg % BOX2 != 0)
        count2 = CalMinBoxCount(kg - BOX1, count + 1);
    else
        count2 = count + kg / BOX2;

    if (count1 < 0)
        return count2;

    if (count2 < 0)
        return count1;

    if (count1 <= count2)
        return count1;
    else
        return count2;

}