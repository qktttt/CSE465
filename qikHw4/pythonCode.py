def fillTmp(modelString, personInfo):
	resultString = modelString.format(
		NAME=personInfo["name"], COURSE=personInfo["course"],
		Id=personInfo["id"], DUE=personInfo["due"], 
		SUBMITTED=personInfo["submitted"], MINUTESLATE=personInfo["minuteslate"],
		LATEDEDUCTION=personInfo["latededuction"], P1=personInfo["p1"],
		P1COMMENTS=personInfo["p1comments"], P2=personInfo["p2"],
		P2COMMENTS=personInfo["p2comments"], SUBTOTAL=personInfo["subtotal"],
		TOTAL=personInfo["total"]		
	) # replace part in model string with customized personal information
	return resultString

def writeInformation(infoString, outputFilename):
	#finish writing the file
	targetFile = open(outputFilename, "w") # open file
	targetFile.write(infoString)
	targetFile.close() # close file

def processTmp(modelFilename):
	totalString = ""
	modelFile = open(modelFilename) # open file
	for i in modelFile.readlines():
		totalString += i
	modelFile.close() # close file
	totalString = totalString.replace("<<", "{")
	totalString = totalString.replace(">>", "}")
	return totalString

def readInfoFile(infoFilename):
	""" read the info file, and return a list containing dict
		:param 
			infoFile (file object) : the 
				file object of students information
		:return
			list containing dict:
				[
					{student1Name: ..., studentCourse: ..., ...} 
					{student2Name:...... } 
					{...}
				]
	"""
	# open the file
	
	# using for loop to construct the result
	
	# close file
	
	# return the result
	pass
	
if __name__ == "__main__":
	fileInfoName = argv[1] # *.tsv file
	fileModelName = argv[2] # *.tmp file 

	# in a loop read the file
	persons = infoFile.readlines()
	for i in person:
		# seperate information 
	