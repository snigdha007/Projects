module FSAnalysis
//// F# library to analyze Chicago crime data
//
// Snigdha Sultana
// U. of Illinois, Chicago
// CS341, Fall2016
// Homework 5//
#light

open System
open FSharp.Charting
open FSharp.Charting.ChartTypes
open System.Drawing
open System.Windows.Forms


let private ParseOneCrime (line : string) = 
  let elements = line.Split(',')
  let date = elements.[0]
  let iucr = elements.[1]
  let arrested = Convert.ToBoolean(elements.[2])
  let domestic = Convert.ToBoolean(elements.[3])
  let area = Convert.ToInt32(elements.[elements.Length - 2])
  let year = Convert.ToInt32(elements.[elements.Length - 1])
  (date, iucr, arrested, domestic, area, year)
/////////////////////////////////////
let private ParseIUCR (line : string) = 
  let elements = line.Split(',')
  let iucr = elements.[0]
  let priDes =elements.[1]
  let secDes =elements.[2]
  (iucr,priDes,secDes)

let private ParseArea (line : string) = 
  let elements = line.Split(',')
  let code =Convert.ToInt32( elements.[0])
  let Area =  (elements.[1])
  
  (code, Area)
//
let private ParseAreaChi (line : string) = 
  let elements = line.Split(',')
  let code = Convert.ToInt32(elements.[0])
  let Area =  (elements.[1])
  
  (code, Area)
////////////////////////////////
let private ParseCrimeData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseOneCrime
  |> Seq.toList

let private ParseICUR_1 filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseIUCR
  |> Seq.toList

let private ParseArea1 filename=
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseArea
  |> Seq.toList
let private ParseAreaChi1 filename=
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseAreaChi
  |> Seq.toList

let private CrimesThisYear crimes crimeyear = 
  let crimes2 = List.filter (fun (_, _, _, _, _, year) -> year = crimeyear) crimes
  let numCrimes = List.length crimes2
  numCrimes

let private Arrest crimes crimeyear = 
  let arrest1 = List.filter (fun (_, _, arrest, _, _, year) -> arrest = true && year=crimeyear ) crimes
  let numArrest = List.length arrest1
  numArrest

let private AreaMatch crimes code crimeyear  = 
  let Area1 = List.filter (fun (_, iucr, arrest, dem, code, year) -> iucr=iucr && code= code && arrest=true && dem=true  && year=crimeyear ) crimes
  let numcrime = List.length Area1
  numcrime

let private ICUR  file iucrenter =
  let iucrfilter= List.filter (fun (iucr,_,_) -> iucr=iucrenter) file
  let numiucr = List.length iucrfilter
  if numiucr = 0 then
    "unknown crime code"
  else 
   let (iucr, rdescr, sdescr) = iucrfilter.Head 
   rdescr + " - " + sdescr


let private Area  file areaenter =
  let Areafilter= List.filter (fun (_,area) -> area=areaenter) file
  let numArea = List.length Areafilter
  if numArea = 0 then
    0
  else 
   let (code,area) = Areafilter.Head
   code

let private Areafile file =
 let Areafilter= List.filter (fun (code, _) -> code=code ) file
 let numcode = List.length Areafilter
 numcode
    
let private AreaCrimes file areacode =
 let Areafilter= List.filter (fun (_,_,_,_, code, _) -> code= areacode  ) file
 let numcode = List.length Areafilter
 numcode
     
////////////////////////////////////////
let CrimesByYear(filename) = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes =ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts
 
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear
 
  let myChart = 
    Chart.Line(countsByYear, Name="Total # of Crimes")
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl



  ///////////////////////////////////////////////////////
let ArrestByYear(filename) = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes =ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts1 = List.map (fun year -> Arrest crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts1
  let counts2 = List.map (fun year -> CrimesThisYear crimes year) range
  let ArrByYear = List.map2 (fun year count -> (year, count)) range counts2
  
  // plot:
  //
  let myChart = 
    Chart.Combine([
                   Chart.Line(ArrByYear, Name= "Total NUmber of crimes.")
                   Chart.Line(countsByYear,Name="#of Arrests.")
                   ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl


//////////////////////////////////////////////////////
let IUCR_des1(filename, enteredCode) = 
  
  let ICUR_1 = ParseICUR_1 "IUCR-codes.csv" //parsing
  let description= ICUR  ICUR_1 enteredCode
  let counts1 = List.map (fun iucr -> ICUR iucr ICUR_1) //not needed
  let crimes =ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  printf "Year range %A" range
  let counts1 = List.map (fun year -> Arrest crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts1
  let counts2 = List.map (fun year -> CrimesThisYear crimes year) range
  let ArrByYear = List.map2 (fun year count -> (year, count)) range counts2
  let myChart = 
    Chart.Combine([
                    Chart.Line(ArrByYear, Name= "Total  of crimes.")
                    Chart.Line(countsByYear,Name=description)
                  ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl


  /////////////////////////////
let AreaCrime(filename, enteredCode) = 
   let Area_1 = ParseArea1 "Areas.csv" //parsing
   printfn "Calling AreaCrimes: %A" filename
   let Areades= Area  Area_1 enteredCode
   printf "%A" Areades
   let crimes =ParseCrimeData filename
   
   let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
   let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
   let range  = [minYear .. maxYear]
   
   let counts = List.map (fun year -> CrimesThisYear crimes year) range
   let countsByYear = List.map2 (fun year count -> (year, count)) range counts
   let counts2 = List.map (fun year  ->  AreaMatch crimes  Areades year) range
   printf " it is area count %A" counts2
   let countsByArea = List.map2 (fun year count -> (year, count)) range counts2
   
   let counts1 = List.map (fun year -> Arrest crimes year) range
   let ArrestByYear = List.map2 (fun year count -> (year, count)) range counts1
   let myChart = 
    Chart.Combine([
                    Chart.Line(countsByYear, Name= "Total  of crimes.")
                    Chart.Line(countsByArea, Name = enteredCode)
                  ])
   let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
   let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
   myChartControl
 ///////////////////////////////////////////////////////////////////
let Chicago(filename)=
  
   let crimes=ParseCrimeData filename
   let (_, _, _, _, mincode, _) = List.minBy (fun (_, _, _, _, area, _) -> area) crimes
   let (_, _, _, _, maxcode, _) = List.maxBy (fun (_, _, _, _, area, _) -> area) crimes
   let range  = [mincode .. maxcode]
   let counts= List.map(fun area ->(AreaCrimes crimes area))range
   let countsByArea=List.map2(fun area count->(area,count))range counts

   let myChart = 
    Chart.Line(countsByArea, Name="Total Crimes by Chicago Area")
   let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
   let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
   myChartControl