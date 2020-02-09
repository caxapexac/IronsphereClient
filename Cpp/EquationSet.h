//
// Created by alex on 2/6/20.
//

#ifndef UNTITLED1_MAIN_H
#define UNTITLED1_MAIN_H

#include <memory>
#include <vector>
#include <iostream>
#include <algorithm>
#include <cmath>

#define MINIMUM 0.00000000001

class EquationSet {
private:
    class Equation {
    private:
        std::shared_ptr<std::vector<double>> arguments;
        double answer;

    public:
        explicit Equation(unsigned int length);
        Equation();
        std::shared_ptr<std::vector<double>> &getArguments();

        void setArguments(const std::shared_ptr<std::vector<double>> &arguments);

        double getAnswer() const;
        void setAnswer(double answer);
    };

    unsigned int width = 0;
    unsigned int height = 0;
    std::shared_ptr<std::vector<std::shared_ptr<Equation>>> matrix;

    static void multiract(std::shared_ptr<std::vector<std::shared_ptr<Equation>>> matrix, unsigned int what, unsigned int from, double multiplier);
    static bool comparator(const std::shared_ptr<Equation>& first, const std::shared_ptr<Equation>& second);

public:
    EquationSet();

    void commit();
    void triangulate();
    void intermediate();
    void interpretate();
    void diagonalise();

    void print(std::shared_ptr<std::vector<std::shared_ptr<Equation>>> matrix);
    void publish(std::shared_ptr<std::vector<std::shared_ptr<Equation>>> matrix);
};

#endif //UNTITLED1_MAIN_H
