   M S B A M L   `   `   `  ����  PokemonLikeCsharp)    #PokemonLikeCsharp.EditPokemonWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Modifier Pokémon��5   	   ���#F0F4F8 � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5	         ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth	   Color��%  &	        �� 5   
   " ��6$   .�5      ��  � �� �#2196F36+   �� 5       � ��
 �����6+   �� 5       � ��$
 12,6q�6(   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� �#1976D26,   �� 5       � ��$ 2q�60   �� 5       � ��$ 10q�6'   �� 5       � ��$ Center=�64   �� 5       �@J�Effect 5        5      $ 5Q�6'   $ 2Q�66   $
	 Gray��6F   5      5      5      .��5      � $��30q�6   
 � RowDefinitions
 5   
   �� 5       $
��Auto �6   �� 5!      $��* �6   �� 5"      $
��Auto �6   .+�5&   
   �� $��Modifier Pokémon��6   $��32(�6,   $
��Bold"�6:   ���#333$��Center=�5'      $��10q�61   �� 5*   
   $��1��6   $��Center=�6"   $��Center=�6?   $	��400��6Z   .+�5+      �� $��Nom du Pokémon��6   $
��0,10q�6.   $��16(�6<   $��SemiBold"�6J   �� 5,      -   5         ��Name$ txtName��5,      $��8q�6'   $	��0,5q�63   ���#B0BEC5$��1q�6V   �� 5.      $��Santé��6   $
��0,10q�6%   $��16(�63   $��SemiBold"�6A   �� 5/      -   5        $ 	txtHealth��5/      $��8q�6)   $	��0,5q�65   ���#B0BEC5$��1q�6X   �� 51      $��URL de l'image��6   $
��0,10q�6.   $��16(�6<   $��SemiBold"�6J   �� 52      -   5        $ txtImageUrl��52      $��8q�6+   $	��0,5q�67   ���#B0BEC5$��1q�6Z   �� 55      $
��0,20q�6   ���#B0BEC5$��1q�69   $	��150��6M   $	��150��6Y   $��Center=�6f   ._�56      �� -   5         ��Name$ 
imgPokemon��56      $��Uniform=�6,   57      58      �� 5;   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��20q�6X   .+�5<      �� -   5        $��Sauvegarder��5<      #��[  6A   5=      5>      5?      