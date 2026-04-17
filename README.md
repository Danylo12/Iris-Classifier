A C# implementation of a Decision Tree algorithm from scratch for the classification of the classic Fisher's Iris dataset. This project demonstrates machine learning fundamentals, clean architecture, and advanced C# features like delegates and cross-validation.


Key Features
 * Custom Decision Tree: Built from the ground up without using high-level ML libraries (like Scikit-Learn or ML.NET).
 * Dynamic Split Criterion: Use of C# Delegates (Func<int[], double>) to allow users to swap between different evaluation metrics.
 * Gini Impurity (Default implementation).
 * Shannon Entropy (Optional custom implementation).
 * K-Fold Cross-Validation: Built-in validation system (K=5) to ensure the model's accuracy and robustness.


Architecture Overview
The project is divided into several modular components:
* Drzewo.cs: The core engine that manages the recursive tree-building process.
* Wezel.cs: Abstract base class for tree nodes using the Strategy Pattern.
* WezelDecyzyjny.cs & WezelLisci.cs: Implementation of decision logic and leaf nodes.
* CV.cs: Logic for splitting data into training and testing folds.
* DataProcessing.cs: Utilities for data standardization and normalization.


Dataset
This project uses the Iris Flower Dataset (found in bezdekIris.data). It classifies flowers into three species based on four features:
* Sepal length
* Sepal width
* Petal length
* Petal width


How run the code:
Git clone -> go to right folder -> print "make run" or "dotnet run"
