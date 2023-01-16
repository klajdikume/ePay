// See https://aka.ms/new-console-template for more information
using ePayTasks;

Console.WriteLine("Hello, World!");
/*
    
cartige enums -> 10, 50, 100

pay out(combination of cartiges)	-> 30, 50, 60, 80, 140 ...

What is given:
array of cartige    -> money print options
array of payouts    -> combination -> sum of cartige options

kufiza -> ndarje e shumfishit te payout me cartige option
hottest idea:

input -> 230 EUR
            gjej max print bill

find max bill print for payout(int payout) {
    max = cartige[0]
    for j <= cartige.Length
        if(max < cartige)
            max = cartige
    return max
}

sort cartiges, find max less then a number

for i <= payouts.Length
    var payout = payouts[i];
    var maxBillPrint = find max bill print for payout()
    var pp = (payout / maxBillPrint);
    if(payout % maxBillPrint == 0){
        Console.WriteLine(payout * pp = maxBillPrint)
    }
    else 
    {
        payout - (maxBillPrint * pp) = newPayout;
        recursiveMaybe(cartiges, newPayout)
    }

input -> 60
        pp 10 = 6
            6 * 10 EUR = 60 EUR
        pp 50 = 1
            1 * 50 EUR = 50 EUR
            60 EUR - 50 EUR = 10 EUR 
                10 EUR = 1
                1 * 10 EUR = 10 EUR
            1 * 50 EUR + 1 * 10 EUR = 60 EUR [reached]
input -> 140 
        14 * 10 EUR = 140 EUR 
        pp 50 = 2
            2 * 50 EUR = 100 EUR [not reached]
                140 EUR - 100 EUR = 40 EUR
                pp 10 = 4
                    4 * 10 EUR = 40 EUR
            2 * 50 EUR + 4 * 10 EUR = 140 EUR [reached]
            1 * 50 EUR + 9 * 10 EUR = 140 EUR [reached]
        pp 100 = 1
            1 * 100 EUR = 100 EUR
            140 EUR - 100 EUR = 40 EUR
                  pp 10 = 4
                    4 * 10 EUR = 40 EUR
            1 * 100 EUR + 4 * 10 EUR = 140 EUR
input -> 30 
        pp 10 = 3
            3 * 10 EUR = 30 EUR correct
input -> 50
        pp 10 = 5
            5 * 10 EUR = 50 EUR
        pp 50 = 1
            1 * 50 EUR = 50 EUR
input -> 100
        pp 10 = 10
            10 * 10 EUR = 100 EUR
        pp 50 = 2
            2 * 50 EUR = 100 EUR
        pp 50 is bigger than the minimum and we have 2
            -> 50
                pp 10 = 5
                    5 * 10 EUR = 50 EUR -> 5 * 10 + 1 * 50 = 100 EUR
        pp 100 = 1
            1 * 100 EUR = 100 EUR

calculate for each payout the possible combinations which the ATM can pay out

Psh (100)
-	10 x 10
-	1 x 50 EUR + 5 x 10 EUR
-	2 x 50 EUR
-	1 x 100 EUR

 */
// heres * cartige + heres * cartige ... N = payout
/*
 DS
    cartiges (money print available to be combined and form a pay out option)
    input: payout number -> 30
    cartige + cartige = payout number
    idea-> foreach cartige -> create possible combination
    10 *
    
    pp
    100 : 10 = 10
    - 10 x 10 EUR
    - 
    pp 
    100 : 50 = 2
    - 2 x 50 EUR
    pp 
    50 : 

    input 30
        -> pp maxBillPrint = 10
        pp 10 = 3
            
    input 50
        -> pp maxBillPrint = 50
        pp 50 = 1   -> plotepjesetim -> payout eshte sa bill print
            50 EUR * 1 = 50 EUR [reached] 
            maxBillPrint = 50 > minimum -> can be split
            fillo nga min
            50 : 10 = 5
            5 * 10 EUR = 50 EUR

            10 is = min return
    input 230
        pp maxBillPrint = 100
        pp 230 / 100 EUR = 2.ca 
        if(mbetje) 
            230 - (100 EUR * 2) = 30 EUR
                30 EUR / 10 (maxBillPrint) = 3
                no mbetje -> 3 * 10 EUR = 30 EUR
        push([100, 2],[10, 3])
        current row keys maxBillPrint is > than minimum
            100 has maxBill Print 50 > 10 
     input ([100, 2], [10, 3])
        [100, 1]
        100 maxBill 50 = 2
            2 * 50 = 100 EUR 
            no mbetje
        [50, 2]
        push ([100, 1], [50, 2], [30, 3])
         current row keys maxBillPrint is > than minimum
            100 has maxBill Print 50 > 10 
      input ([100, 1], [50, 2], [30, 3])
            [100, 0] -> vanish :D
        50 * 2
        [50, 2]
       push([50, 2], [50, 2], [50, 2], [30, 3])
    
    CombinationModel 
    {
        [[230,1]]
        CombinationLine [pair[50, 2], [50, 2], [50, 2], [30, 3]],
        CombinationLine [[50, 2], [50, 2], [50, 2], [30, 3]],
        CombinationLine [[50, 2], [50, 2], [50, 2], [30, 3]]
        ...
    }   
 */




List<CombinationModel> combinationModels = new List<CombinationModel>();


int findmaxbillprintforpayout(List<int> cartiges, int payout) {
    return cartiges.Where(x => x < payout).Max();
}

void discoverPossibleCombinations(List<int> payouts, List<int> cartiges)
{
    var minimumBillPrint = cartiges.Min();

    for (int i = 0; i < payouts.Count; i++)
    {
        
        Pair pair = new Pair();
        pair.Bill = payouts[i];
        pair.Count = 1;

        CombinationLine combinationLinePairs = new CombinationLine();
        CombinationModel combinationModel = new CombinationModel();

        var model = combinationsForAPayout(pair, cartiges, minimumBillPrint, combinationLinePairs, combinationModel);
        
        model.Payout = pair.Bill;
        combinationModels.Add(model);


    }
}

CombinationLine splitPayOutLeft(CombinationLine currentCombinationPairs, List<int> cartiges, int remainingPayout)
{
    var maxBillPrint = findmaxbillprintforpayout(cartiges, remainingPayout);

    int division = remainingPayout / maxBillPrint;

    var pair = new Pair();
    pair.Bill = maxBillPrint;
    pair.Count = division;

    currentCombinationPairs.Pairs.Add(pair);

    if (remainingPayout % maxBillPrint != 0)
    {
        // has still remainings
        splitPayOutLeft(currentCombinationPairs, cartiges, (remainingPayout - (maxBillPrint * division)));

    }
    
    return currentCombinationPairs;
}

CombinationModel combinationsForAPayout(Pair payout, List<int> cartiges, int minimumBillPrint, CombinationLine combinationLine, CombinationModel combinationModel)
{
    // [230, 1]
    // 

    if(payout.Count > 1)
    {
        // create pairs [bill,1] -> to be splited more + [bill, c - 1]
        var splitedPair = new Pair();
        splitedPair.Bill = payout.Bill;
        splitedPair.Count = 1;

        payout.Count -= 1;
    }

    // CombinationLine combinationLine = new CombinationLine(); // has a list of pairs
    List<Pair> pairs = new List<Pair>();
    

    // payout first time being splited
    var maxBillPrint = findmaxbillprintforpayout(cartiges, payout.Bill);

    int division = payout.Bill / maxBillPrint;
      

    var pair = new Pair();
    pair.Bill = maxBillPrint;
    pair.Count = division;

    combinationLine.Pairs.Add(pair);
    if (payout.Bill % maxBillPrint != 0)
    {
            
        var combinationSplitResult = 
            splitPayOutLeft(combinationLine, cartiges, (payout.Bill - (maxBillPrint * division)));

        combinationModel.CombinationLines.Add(combinationSplitResult);

    }
    else
    {
        combinationModel.CombinationLines.Add(combinationLine);
    }

    // here we have combination line ready to go to the Model

    // check pontential next combination Line as input

    // one of the Pair bill is bigger than minimal cartige option (that pair can be splited)
    // copy combinationLine without pair which the comparison is true

    // prepare next combination

    // pair -> splited Pair from combinationLines
    // combinationLines -> without the Pair
    bool isAnyPairThatCanBeSplited = false;

    var nextPair = new Pair();
    var nextCombinationLines = new CombinationLine();
    foreach(var c in combinationModel.CombinationLines)
    {
        
        foreach(var p in c.Pairs)
        {
            if ((p.Bill > minimumBillPrint) && (nextPair.Bill == 0))
            {
                nextPair.Bill = p.Bill;
                nextPair.Count = p.Count - 1;
                isAnyPairThatCanBeSplited = true;
                continue;
            }
            
            nextCombinationLines.Pairs.Add(p);
        }
    }

    if (isAnyPairThatCanBeSplited)
        return combinationsForAPayout(nextPair, cartiges, minimumBillPrint, nextCombinationLines, combinationModel);
    else
        return combinationModel;

}

List<int> cartiges = new List<int> { 10, 50, 100 };
List<int> payouts = new List<int> { 230 };

discoverPossibleCombinations(payouts, cartiges);

