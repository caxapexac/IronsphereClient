#include "EquationSet.h"

EquationSet::Equation::Equation(unsigned int length) {
    this->arguments = std::make_shared<std::vector<double>>(std::vector<double>());
    double val;
    for (int i = 0; i < length; ++i) {
        std::cin >> val;
        this->arguments->emplace_back(val);
    }
    std::cin >> this->answer;
}

std::shared_ptr<std::vector<double>>& EquationSet::Equation::getArguments() {
    return arguments;
}

void EquationSet::Equation::setArguments(const std::shared_ptr<std::vector<double>> &arguments) {
    Equation::arguments = arguments;
}

double EquationSet::Equation::getAnswer() const {
    return answer;
}

void EquationSet::Equation::setAnswer(double answer) {
    Equation::answer = answer;
}

EquationSet::Equation::Equation() {}


EquationSet::EquationSet() {
    while (this->height == 0) {
        std::cout << "Enter the number of equations:" << std::endl;
        std::cin >> this->height;
    }

    while (this->width == 0) {
        std::cout << "Enter the number of members of the longest equation:" << std::endl;
        std::cin >> this->width;
    }

    std::cout << std::endl;

    this->matrix = std::make_shared<std::vector<std::shared_ptr<Equation>>>(std::vector<std::shared_ptr<Equation>>());
    for (int i = 0; i < this->height; ++i) {
        std::cout << "Enter the equation number " << i + 1 << ". Enter only numeric values divided by space. Put answer in the end." << std::endl;
        this->matrix->emplace_back(std::make_shared<Equation>(Equation(this->width)));
    }

    print(matrix);
}

void EquationSet::multiract(std::shared_ptr<std::vector<std::shared_ptr<Equation>>> matrix, unsigned int what, unsigned int from, double multiplier) {
    unsigned long len = matrix->at(from)->getArguments()->size();
    double result;
    for (int i = 0; i < len; ++i) {
        result = matrix->at(from)->getArguments()->at(i) - multiplier * matrix->at(what)->getArguments()->at(i);
        if (std::abs(result) <= MINIMUM) result = 0.0;
        matrix->at(from)->getArguments()->at(i) = result;
    }
    result = matrix->at(from)->getAnswer() - multiplier * matrix->at(what)->getAnswer();
    if (std::abs(result) <= MINIMUM) result = 0.0;
    matrix->at(from)->setAnswer(result);
}

bool EquationSet::comparator(const std::shared_ptr<Equation>& first, const std::shared_ptr<Equation>& second) {
    double left, right;
    for (int i = 0; i < first->getArguments()->size(); ++i) {
        left = first->getArguments()->at(i);
        right = second->getArguments()->at(i);
        if ((left == 0) && (right == 0)) continue;
        if ((left == 0) && (right != 0)) return false;
        if ((left != 0) && (right == 0)) return true;
        return left > right;
    }
    return false;
}

void EquationSet::commit() {
    triangulate();
    intermediate();
}

void EquationSet::triangulate() {
    std::cout << "Solving using Gaussian method:" << std::endl;
    unsigned int lower = (width < height) ? (width) : (height);
    for (int k = 0; k < lower; ++k) {
        sort(this->matrix->begin() + k, this->matrix->end(), comparator);
        print(matrix);
        for (int i = 1 + k; i < height; ++i) {
            if (matrix->at(i)->getArguments()->at(k) == 0) {
                break;
            }
            double mult = matrix->at(i)->getArguments()->at(k) / matrix->at(k)->getArguments()->at(k);
            multiract(matrix, k, i, mult);
        }
    }
    print(matrix);
}

void EquationSet::intermediate() {
    std::cout << "Summing up results:" << std::endl;

    bool cleared = false;
    bool nulled = true;
    std::vector<double> nulls;
    for (int i = 0; i < height; ++i) {
        for (int j = 0; j < width; ++j) {
            if (matrix->at(i)->getArguments()->at(j) != 0) nulled = false;
        }
        if (nulled) {
            if (matrix->at(i)->getAnswer() == 0) {
                cleared = true;
                matrix->erase(matrix->begin() + i);
                height--;
                i--;
            } else {
                nulls.emplace_back(matrix->at(i)->getAnswer());
            }
        }
        nulled = true;
    }
    if (cleared) {
        std::cout << "Null lines were removed. Now matrix is:" << std::endl;
        if (matrix->empty()) {
            std::cout << "Gone!" << std::endl;
            return;
        } else print(matrix);
    }

    nulled = true;
    for (double null : nulls) {
        if (null != 0) nulled = false;
    }
    if (!nulled) {
        std::cout << "Some equations contradict the others. Not solvable.\n--Rouché–Capelli" << std::endl;
        return;
    }

    if (width == height) {
        std::cout << "This is a square matrix. Each variable is a number." << std::endl;
        diagonalise();
    } else if (width > height) {
        std::cout << "This is a rectangular matrix. There will be some undefined variables." << std::endl;
        interpretate();
    } else {
        std::cout << "This matrix can not exist. Please, contact developer and show him this result." << std::endl;
    }
}

void EquationSet::interpretate() {
    std::cout << "Adding extra lines for undefined variables:" << std::endl;
    std::shared_ptr<std::vector<std::shared_ptr<Equation>>> contramatrix;
    contramatrix = std::make_shared<std::vector<std::shared_ptr<Equation>>>(std::vector<std::shared_ptr<Equation>>(width));
    std::vector<unsigned int> map(width);

    std::fill(map.begin(), map.end(), -1);
    for (int k = 0; k < height; ++k) {
        for (int i = 0; i < width; ++i) {
            if (matrix->at(k)->getArguments()->at(i) != 0) {
                map[i] = k;
                break;
            }
        }
    }

    for (int i = width - 1; i >= 0; --i) {
        contramatrix->at(i) = std::make_shared<Equation>(Equation());
        contramatrix->at(i)->setArguments(std::make_shared<std::vector<double>>(std::vector<double>(width)));

        if (map[i] != -1) {
            contramatrix->at(i) = matrix->at(map[i]);
        }
    }

    matrix = contramatrix;
    height = width;
    print(matrix);

    diagonalise();
}

void EquationSet::diagonalise() {
    std::cout << "Diagonalising the matrix:" << std::endl;
    double middler, mult;
    for (int i = width - 1; i >= 0 ; --i) {
        for (int j = i - 1; j >= 0; --j) {
            middler = matrix->at(i)->getArguments()->at(i);
            if (middler != 0) {
                mult = matrix->at(j)->getArguments()->at(i) / middler;
                multiract(matrix, i, j, mult);
            }
        }
        print(matrix);
    }

    for (int k = 0; k < height; ++k) {
        middler = matrix->at(k)->getArguments()->at(k);
        if (middler != 0) {
            for (int i = k; i < width; ++i) {
                matrix->at(k)->getArguments()->at(i) = matrix->at(k)->getArguments()->at(i) / middler;
            }
            matrix->at(k)->setAnswer(matrix->at(k)->getAnswer() / middler);
        }
    }

    publish(matrix);
}



void EquationSet::print(std::shared_ptr<std::vector<std::shared_ptr<Equation>>> matrix) {
    for (int j = 0; j < this->height; ++j) {
        for (int i = 0; i < this->width; ++i) {
            std::cout << matrix->at(j)->getArguments()->at(i) << " ";
        }
        std::cout << ": " << matrix->at(j)->getAnswer() << std::endl;
    }
    std::cout << std::endl;
}

void EquationSet::publish(std::shared_ptr<std::vector<std::shared_ptr<EquationSet::Equation>>> matrix) {
    double definitor;
    for (int j = 0; j < this->height; ++j) {
        std::cout << "X" << j + 1 << " = ";
        if (matrix->at(j)->getArguments()->at(j) != 0) {
            for (int i = j + 1; i < this->width; ++i) {
                definitor = matrix->at(j)->getArguments()->at(i);
                if (definitor != 0) std::cout << definitor << "*x" << i + 1 << " + ";
            }
            std::cout << matrix->at(j)->getAnswer() << std::endl;
        } else {
            std::cout << "undefined" << std::endl;
        }
    }
    std::cout << std::endl;
}




