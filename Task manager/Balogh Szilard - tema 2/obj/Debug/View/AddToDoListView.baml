   M S B A M L   `   `   `  ����R  NBalogh Szilard - tema 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Balogh_Szilard___tema_2.ViewBalogh_Szilard___tema_2.View  5      U/clr-namespace:Balogh_Szilard___tema_2.ViewModel!Balogh_Szilard___tema_2.ViewModel  6G   2    ,Balogh_Szilard___tema_2.View.AddToDoListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Balogh_Szilard___tema_2.View     5      Blocal1/clr-namespace:Balogh_Szilard___tema_2.ViewModel     6G     � DataContext  5	      <   6Balogh_Szilard___tema_2.ViewModel.AddToDoListViewModel  5
   
   6(   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��List title:��6   �� 5   
   $��1��6   $	��200��6   ��6+   �� *ToDoListName+ �� Mode$ TwoWay=��� 5   
   $��2��6   $��List image:��6   �� 5   
   $��3��6   $	��200��6   ��6+   �� *ToDoListImage+$ TwoWay=��� 5   
   $��4��6   $��OK��6   $��10q�6+   ��67   �� *
AddCommand+5      5      