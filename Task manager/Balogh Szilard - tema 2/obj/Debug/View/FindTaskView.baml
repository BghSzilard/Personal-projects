   M S B A M L   `   `   `  ����R  NBalogh Szilard - tema 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Balogh_Szilard___tema_2.ViewBalogh_Szilard___tema_2.View  5      U/clr-namespace:Balogh_Szilard___tema_2.ViewModel!Balogh_Szilard___tema_2.ViewModel  6G   /    )Balogh_Szilard___tema_2.View.FindTaskView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Balogh_Szilard___tema_2.View     5      Blocal1/clr-namespace:Balogh_Szilard___tema_2.ViewModel     6G     � DataContext  5	      9   3Balogh_Szilard___tema_2.ViewModel.FindTaskViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��/Images/Search.png��6-   $	��100��6I   $	��100��6U   $��10q�6b   �� 5   
   $��0��6   $��1��6"   $��10q�62   .+�5      �� $��
Find Tasks��6   $
��Bold"�6*   $��24(�6<   �� 5      $#��Find tasks in all to-do lists��6   $��16(�6=   5      �� 5   
   $��1��6   $��0��6   $��
Search By:��6-   �� 5   
   -   5         ��Name$ searchTypeComboBox��5   �   $��1��6d   $��1��6t    �� SelectedItem 6   �� *SelectedItem+ �� Mode$ TwoWay=���6F   �� *Items+5      �� 5    
   $��2��6   $��0��6   $��Search Term:��6-   $y�Visible=�6D   ��5!      �� 5"       �� 
TargetType" ��6   .�5#      ��  �� Property � y� �� Value$ Visible=�63   	 �� Triggers	 5$      �� 5%      
 �� Binding
 6&   �� *SelectedItem.Content+ �� ElementName$ searchTypeComboBox�� �� Value Deadline6o   .a�5&      ��  � y�$ 	Collapsed=�6;   5'      5)      5+      (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ deadlineDatePicker��5,   2   $��2��6   $��1��6"   y�6N   �� *DeadlineVisibility+   SelectedDate 6x   �� *SearchDeadline+$ TwoWay=���5-      �� 5.      "  6   .�5/      ��  � y�$ 	Collapsed=�63   	 50      �� 51      
 6&   �� *SelectedItem.Content+$ searchTypeComboBox�� Deadline6o   .a�52      ��  � y�$ Visible=�6;   53      55      57      �� 58   
   -   5         ��Name$ nameSearchTermTextBox��58   /   $��2��6   $��1��6   ��6N   �� *
SearchTerm+$ TwoWay=�y�6x   �� *NameSearchTermVisibility+�� 59   
   $��3��6   $��0��6   $��Search results:��6-   �� 5;   
   $��3��69   $��1��6F   ��6   �� *SearchResults+ �� View 5<      �� 5=      .P�5>      �� $
��Task��6%    �� DisplayMemberBinding 63   �� *Title+�� 5?      $
��Path��6%    63   �� *Path+�� 5@      $��Deadline��6%    67   �� *
Deadline+5A      5C      �� 5G   
   $��4��6   $��2��6   $��Search��62   ��6C   �� *SearchCommand+5H      5I      