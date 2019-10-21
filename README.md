# trials
#Problem

  To create a User Interface to measure the dimensions and estimate whether they can carry a package in a car or not. Also add additional features.
  
#Implementation:

  The solution runs on Android 8 and above. Attached video indicates the working of the solution.
  
#Package used:

  Unity 2019.2.8f1
  ARCORE SDK
    
#Solution

  Allows user to choose the car model.
  
  The user can name and measure more than one package.
  
  Developed a tool to measure the size of the package using ARCORE.
  
  Also provide facility to enter the dimensions of the package (In case, the surface is not identified, or user already knows the dimensions).
  
  Creates a virtual asset for the measured package.
  
  After measuring, it displays how it fits into the model trunk (indicating dimensions).
  
  Ask questions “Can we stack?” to offer a better solution.
  
  Modular solution that can be extended .
  
#Improvements

  If given more time, I would like to make the following improvements in the application
  
  Store asset using JSON scripts or playerprefs. Also include regular travel suitcases as an AR object.
  
  Create a better asset for the trunk of the car.
  
  Develop algorithm to autofit the virtual object onto the car trunk.
  
  Counter - The counter to indicate the available space can be created by calculating the volume left with respect to the known dimensions of the created package & car.
  
  Also provide drag and drop options for the augmented package.
