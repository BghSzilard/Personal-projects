   M S B A M L   `   `   `  ����R  NBalogh Szilard - tema 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Balogh_Szilard___tema_2.ViewModel!Balogh_Szilard___tema_2.ViewModel  5      7    1Balogh_Szilard___tema_2.View.AddTaskDialogBoxView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Balogh_Szilard___tema_2.ViewModel     5        � DataContext  5	      A   ;Balogh_Szilard___tema_2.ViewModel.AddTaskDialogBoxViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��
Task Name:��6-   �� 5   
   -   5         ��Name$ TaskName��5   ;   $��0��6   $��1��6   $	��200��6/   ��6M   �� *
TaskName+ �� Mode$ TwoWay=��� 5   
   $��1��6   $��0��6   $��	Priority:��6-   �� 5   
   -   5         ��Name$ Priority��5   <   $��1��6   $��1��6    $	��200��60   ��5      �� *PriorityOptions+ �� SelectedItem 65   �� *
Priority+$ TwoWay=�5      �� 5    
   $��2��6   $��0��6   $��Type:��6-   �� 5!   
   -   5        $
 Type��5!   <   $��2��6   $��1��6    $	��200��60   ��5"      �� *CategoryOptions+ 65   �� *SelectedCategory+5$      �� 5%   
   $��4��6   $��0��6   $��Description:��6-   �� 5&   
   -   5        $ Description��5&   ;   $��4��6   $��1��6   $	��200��6/   ��6P   �� *Description+$ TwoWay=��� 5'   
   $��5��6   $��0��6   $��To Do List:��6-   �� 5(   
   -   5        $ ToDoList��5(   <   $��5��6   $��1��6    $	��200��60   ��6N   �� *	ToDoLists+ 6p   �� *SelectedToDoList+��5)      �� 5*      .R�5+      �� ��6    �� *Title+5,      5.      �� 5/   
   $��3��6   $��0��6   $��	Deadline:��6-   (  "System.Windows.Controls.DatePicker  50   
   -   5          Name$ Deadline��50   >   $��3��6   $��1��6"   $	��200��62      SelectedDate 6P   �� *
Deadline+$ TwoWay=��� 51   
   $��6��6   $��1��6"   	 �� Orientation$	 
Horizontal=�62   .+�52      �� -   5        
 ��Name$
 	AddButton��52   C   $	��Add��6   $��
0 10 10 10q�6#   $	��100��67   ��6V   �� *
AddCommand+�� 53      -   5        $
 CancelButton��53   E   $��Cancel��6   $��	0 10 0 10q�6&   $	��100��69   6E   54      55      56      