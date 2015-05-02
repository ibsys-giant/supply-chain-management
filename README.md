# supply-chain-management [![ReviewNinja](http://app.review.ninja/assets/images/wereviewninja-32.png)](http://app.review.ninja/ibsys-giant/supply-chain-management) [![Build Status](https://travis-ci.org/ibsys-giant/supply-chain-management.svg?branch=master)](https://travis-ci.org/ibsys-giant/supply-chain-management)

Travis CI Build: https://travis-ci.org/ibsys-giant/supply-chain-management

**supply-chain-management** is a resource planning tool for the SCM simulation training (http://www.scsimulator.de).

This is a project at the University of Applied Sciences Karlsruhe in the "Simulation in Operations Management" course.
This course work is done by:

 - Manuel Eulenberger 
 - Michael Kunzmann (@MitchK)
 - Zhana (@alzh1011)
 - Frederic Buchner (@bufr1011)

## How to develop

Clone this repository either using the command line...

```
$ git clone ...
```

... or use the GitHub for Windows client (if using Windows). https://windows.github.com/

Then, open the ```SupplyChainManagement.sln``` file with Visual Studio or your preferred IDE. Visual Studio needs to be set up like the following:

 - ```Tools``` >> ```NuGet Package Manager``` >> ```Package Manager Settings``` >> ```General``` >> Set both check boxes in order to restore missing packages from the ```packages.config```
 - ```Tools``` >> ```Extensions and Updates``` >> ```Online``` >> Search for NuGet Adapter and install the plugin in order being able to execute the Unit tests.
