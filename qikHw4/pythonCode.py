"""
Name: Kunting Qi
Course: CSE 465
Description: this is the python implementation of homework 4
Use dictionary to store a student's information
and use list to contain all the dict of each student's information 
"""
import sys

def fillTmp(modelString, personInfo):
	# replace part in model string with customized personal information
	resultString = modelString;
	for key in personInfo:
		resultString = resultString.replace("<<" + key + ">>", personInfo[key])
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
	return totalString


# thie method is TODO
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
	infoFile = open(infoFilename)
	# using for loop to construct the result
	informations = infoFile.readlines()
	result = []
	dataFields = informations[0][:-1].split("\t")
	for i in range(1, len(informations)):
		result.append(
			dict(zip(dataFields, informations[i][:-1].split("\t")))
		)

	# return the result
	return result
	
if __name__ == "__main__":
	fileInfoName = sys.argv[1] # *.tsv file
	fileModelName = sys.argv[2] # *.tmp file 

	# in a loop read the file
	students = readInfoFile(fileInfoName) # list of dictionarys 
	modelString = processTmp(fileModelName) # a string of model
	for i in students:
		outputFileName = i["ID"] + ".txt"
		writeInformation(fillTmp(modelString, i), outputFileName)
	# after the loop is executed
	# the program finish to write all people's output file
	# finish --!