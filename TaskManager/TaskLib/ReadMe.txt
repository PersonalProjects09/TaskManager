Library organization:
	TaskController is responsible for generating the list of tasks, and triggering tasks to run
	TaskController inherits from TaskMethods, which contains all of the methods used by the various tasks
	TaskDetail stores the information about the tasks, and the task object itself
	Tasks0-2 contain the delegates that are linked to the methods in TaskMethods