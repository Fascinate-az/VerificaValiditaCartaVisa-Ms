namespace app;

abstract class Carte
{
    protected long numeroCarta;
    

    protected Carte(long numeroCarta)
    {
        this.numeroCarta = numeroCarta;
    }
    public abstract bool VerificaCarta();

    protected bool AlgoritmoLuhn()
    {
        string cardNumberstring = numeroCarta.ToString();
        List<long> listaCarta = new List<long>();
        int cifra = 0;
        var somma = 0; // da usare quando bisogna sommare tt i numeri
        

        for (int i = cardNumberstring.Length - 1; i >= 0; i--) // CONVERTI IN INT , INSERISCE I NUMERI SINGOLI NELLA LISTA AL CONTRARIO
        {
            cifra = int.Parse(cardNumberstring[i].ToString());
            listaCarta.Add(cifra);
            //Console.WriteLine(cifra);
        }


        for (int i = 1; i < listaCarta.Count; i += 2) // RADDOPPIA I NUMERI A INDEX ALTERNO
        {
            var raddoppio = listaCarta[i] *= 2;

            if (raddoppio > 9)
            {
                raddoppio -= 9;
            }

            listaCarta[i] = raddoppio;

        }


        for (int i = 0;
             i < listaCarta.Count;i++) // sommiamo tutti i numeri, e il totale lo inseriamo nella variabile sommaa
        {

            somma += (int)listaCarta[i];


        }
        
        if (somma % 10 == 0) // DEVE ESSERE DIVISIBILE PER 10 E DARE 0
        {
            
            return BinLookup();
        }
        else
        {
            
            return false;
        }

        
    }

    protected bool VerificaLunghezza(string numeroCarta)
    {
        if (numeroCarta.Length == 16)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    protected bool BinLookup()
    {
        var verificaBin = numeroCarta.ToString().Substring(1, 5);
        var binListVisa = BinList(verificaBin);
        if (binListVisa == true)
        {
            Console.WriteLine("carta valida e bin corretto");
            return true;
        }
        else
        {
            Console.WriteLine("errore verificare i dati");
            return false;
        }
    }
    

    public abstract bool BinList(string substring);



}

    


class Visa: Carte
{
    public Visa(long numeroCarta):base(numeroCarta)
    {
        
    }
    public override bool VerificaCarta()
    {
        var numeroCartaStringa = numeroCarta.ToString();
        

        if (VerificaLunghezza(numeroCartaStringa)==false)
        {
            
            return false;
        }
        else
        {
            
            return AlgoritmoLuhn();
        }
    }
    
    public override bool BinList(string substring)
    {
        string[] binVisa ={ "411111","400006","401288" };
        bool ControlloNumero = false;

        if (binVisa.Contains(substring))
        {
            ControlloNumero = true;
        }
        else
        {
            ControlloNumero = false;
        }
            
            
        return ControlloNumero;
    }
}

class MasterCard : Carte
{
    public MasterCard(long numeroCarta):base(numeroCarta)
    {
        
    }
    public override bool VerificaCarta()
    {
        var numeroCartaStringa = numeroCarta.ToString();

        if (VerificaLunghezza(numeroCartaStringa)== false)
        {
            
            return false;
        }
        else
        {
            
            return AlgoritmoLuhn();
        }
    }

    public override bool BinList(string substring)
    {
        string[] binMasterCard ={ "510510","520082","530125","555555"};
        bool ControlloNumero = false;

        if (binMasterCard.Contains(substring))
        {
            ControlloNumero = true;
        }
        else
        {
            ControlloNumero = false;
        }
            
            
        return ControlloNumero;
    }
}
