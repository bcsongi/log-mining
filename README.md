# Accenture group project
The project consists of two parts.

___
	
## 1. Log mining
		
We have to provide a log viewer page in the form of a single page application. 	
		
### Required technologies: 
.NET, HTML5, JS, C#.
		
### Requirements: 

* Visualize logging data in an aggregated form, i.e. collect multiple log files generated with log4net from multiple applications/folders and display their contents.
* Filtering and sorting should be possible based on various criteria, like application/folder, date, ...
* Should be provided a way to find log records containing a specific text.
* Server-side paging should be in place.
* Caching.
* Logs pattern should be configurable from web.config for each application.

## 2. Customisation libraries
	
We have to provide a web page, which displays an overview of the functions of several customisation libraries. (Customizers write code in order to fulfill their project requirements.)
		
### Required technologies: 
.NET, JS, jQuery, C#, Kendo, Knockout.js, MVC.
		
### Requirements: 
Single page application which displays several information:

* Libraries found within “Approved” folder.
* Libraries found within “Current” folder.
* “CreationDate” of the assembly should be displayed. 
* All custom functions (group-able on custom function types) should be displayed together with the assembly from which they are executed.
* Filtering should be available.
* Custom functions that are current, should be highlighted with green.
* Custom functions that are overridden, should be highlighted with red.