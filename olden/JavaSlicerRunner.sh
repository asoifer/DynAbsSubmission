#Main 
PROGNAME[0]=""
PROGNAME[1]="BH"
PROGNAME[2]="BiSort"
PROGNAME[3]="Em3d"
PROGNAME[4]="Health"
PROGNAME[5]="MST"
PROGNAME[6]="Perimeter"
PROGNAME[7]="Power"
PROGNAME[8]="TreeAdd"
PROGNAME[9]="TSP"
PROGNAME[10]="Voronoi"

SLICINGVARIABLES[0]=0
SLICINGVARIABLES[1]=6
SLICINGVARIABLES[2]=3
SLICINGVARIABLES[3]=5
SLICINGVARIABLES[4]=3
SLICINGVARIABLES[5]=1
SLICINGVARIABLES[6]=2
SLICINGVARIABLES[7]=4
SLICINGVARIABLES[8]=1
SLICINGVARIABLES[9]=5
SLICINGVARIABLES[10]=6

JAVALINE[0]=""
JAVALINE[1]="90"
JAVALINE[2]="89"
JAVALINE[3]="79"
JAVALINE[4]="81"
JAVALINE[5]="57"
JAVALINE[6]="75"
JAVALINE[7]="78"
JAVALINE[8]="53"
JAVALINE[9]="65"
JAVALINE[10]="78"

PARAMS[0]=""
PARAMS[1]="-b 2 -s 2"
PARAMS[2]="-s 4"
PARAMS[3]="-n 2 -d 2 -i 1"
PARAMS[4]="-l 2 -t 2 -s 1"
PARAMS[5]="-v 4"
PARAMS[6]="-l 10"
PARAMS[7]=""
PARAMS[8]="-l 2"
PARAMS[9]="-c 4"
PARAMS[10]="-n 3"

PARAMSNUM[0]=""
PARAMSNUM[1]="2 2"
PARAMSNUM[2]="4"
PARAMSNUM[3]="2 2 1"
PARAMSNUM[4]="2 2 1"
PARAMSNUM[5]="4"
PARAMSNUM[6]="10"
PARAMSNUM[7]="2 2 2 2"
PARAMSNUM[8]="2"
PARAMSNUM[9]="4"
PARAMSNUM[10]="3"

varProgIterator=1
while [ $varProgIterator -lt 11 ]
do

	varProgramName=${PROGNAME[$varProgIterator]}
	varCsFiles=${CSFILES[$varProgIterator]}
	varSlicingVariables=${SLICINGVARIABLES[$varProgIterator]}
	varJavaLine=${JAVALINE[$varProgIterator]}
	varParams=${PARAMS[$varProgIterator]}
	varParamsNum=${PARAMSNUM[$varProgIterator]}

	echo "Executing "$varProgramName" with params: "$varParams

	# Folders
	mkdir -p output\\JavaCompilation\\$varProgramName
	mkdir -p output\\JavaSlicerResults\\$varProgramName

	# Compile and execute code in Java
	varJavaCompilationFolder="output\\JavaCompilation\\"$varProgramName
	javac src\\Java\\$varProgramName\\*.java -g -d $varJavaCompilationFolder
	jar cfe .\\output\\JavaCompilation\\$varProgramName\\$varProgramName.jar $varProgramName -C .\\output\\JavaCompilation\\$varProgramName\\ .
	START_TIME=$SECONDS
	java -cp $varJavaCompilationFolder $varProgramName $varParams
	TIME_JAVA_ORIGINAL=$(($SECONDS - $START_TIME))

	# Execute JS
	START_TIME=$SECONDS
	java -noverify -javaagent:JavaSlicer/tracer.jar=tracefile:output/JavaSlicerResults/$varProgramName/$varProgramName.trace -jar .\\output\\JavaCompilation\\$varProgramName\\$varProgramName.jar $varParams
	TIME_JAVASLICER_TRACE=$(($SECONDS - $START_TIME))

	varIterator=1
	varSlicingVariables=`expr $varSlicingVariables + 1`
	while [ $varIterator -lt $varSlicingVariables ]
	do
		START_TIME=$SECONDS
		#-Xmx2g
		java -jar JavaSlicer/slicer.jar -p output/JavaSlicerResults/$varProgramName/$varProgramName.trace $varProgramName.main:$varJavaLine:{slicingVariable$varIterator} > output/JavaSlicerResults/$varProgramName/$varProgramName_slicingVariable$varIterator.slice
		TIME_JAVASLICER_ANALYSIS=$(($SECONDS - $START_TIME))

		# Format
		#./JavaSlicer/JavaslicerTranslator.exe output/JavaSlicerResults/$varProgramName/$varProgramName_slicingVariable$varIterator.slice output/JavaSlicerResults/$varProgramName/$varProgramName_slicingVariable$varIterator.result output/JavaSlicerResults/$varProgramName/$varProgramName.trace output/JavaSlicerResults/$varProgramName/SummaryResultsFile $TIME_JAVA_ORIGINAL $TIME_JAVASLICER_TRACE $TIME_JAVASLICER_ANALYSIS "$varProgramName" $varParamsNum
		varIterator=`expr $varIterator + 1`
	done

	varProgIterator=`expr $varProgIterator + 1`
done
