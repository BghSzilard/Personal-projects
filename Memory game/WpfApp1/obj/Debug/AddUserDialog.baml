   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.AddUserDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add User��5   	   $	��200��6   $	��300��6'   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��	Username:��6-   �� 5   
   -   5         ��Name$ txtUsername��5   /   $��0��6   $��1��6   ��6D   �� *
Username+ �� Mode$ TwoWay=��� 5   
   $��1��6   $��0��6   $��	Password:��6-   �� 5   
   -   5        $ txtPassword��5   /   $��1��6   $��1��6   ��6D   �� *
Password+$ TwoWay=��� 5   
   $��2��6   $��0��6   $��Image name:��6-   �� 5   
   -   5        $ txtImageName��5   /   $��2��6   $��1��6   ��6E   �� *	ImageName+$ TwoWay=��� 5   
   -   5         ��Name$ 
imgPreview��5   1   $��3��6   $��2��6   $��UniformToFill=�6E   �� 5   
   $��5��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   .+�5      �� -   5        $��10q�5      $��OK��6!   6.   �� 5      $��10q�6   $��Cancel��6!    �� IsCancel . 62   5      5      5      