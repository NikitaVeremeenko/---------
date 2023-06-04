namespace РГР;
class Program
{
    static void Main(string[] args)
    {
        string holes = "ЧЧЧ.БББ";
        Console.WriteLine(holes);
        while (holes!="БББЧЧЧ.") {
            for (int i=0; i<3; i++) {
                holes = holes.Replace(".Б","Б.");
                Console.WriteLine(holes);
                holes = holes.Replace("ЧБ.",".БЧ");
                Console.WriteLine(holes);                
            }
            holes = holes.Replace(".Б","Б.");
            Console.WriteLine(holes);
            for (int i=0; i<3; i++) {
                holes = holes.Replace(".Ч","Ч.");
                Console.WriteLine(holes);                
            }                        
        }
        for (int i=0; i<3; i++) {
            holes = holes.Replace("Ч.",".Ч");
            Console.WriteLine(holes);                
        }         
    }
}

// Б - белый шар
// Ч - чёрный шар
// . - пустая лунка