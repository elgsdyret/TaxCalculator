

def amountContrib(amount, min, max)
    contrib = 0;

    if (amount < min)
        return contrib;
    end
    if (max.nil? || amount <= max)
        return amount - min;
    end
    if amount > max
        return max-min;
    end

    return contrib        
end

def calculate(amount)
	intervals = [{max: 5070.0, rate:10}, {max:8660.0, rate:14}, {max:14070.0, rate:23}, {max:21240.0, rate:30}, {max:40230.0, rate:33}, {rate:45}]
	sum = 0.0;
	currentMin = 0.0;	
	intervals.each do | interval |		
		contrib = amountContrib(amount, currentMin, interval[:max])
		sum += (contrib*interval[:rate])/100						
		currentMin = interval[:max];
	end				
	return sum.round(1)	
end

require 'test/unit'

class TestCalculator < Test::Unit::TestCase

    def test_amountContrib
        assert_equal(500, amountContrib(500, 0, 5070))
    end        

    def test_amountContrib2
        assert_equal(0, amountContrib(500, 5070, 8660))
    end        
	
	def test_zero_first
		assert_equal(500, calculate(5000))
	end

	def test_first_second
		assert_equal(609.2, calculate(5800))
	end

	def test_second_third
		assert_equal(1087.8, calculate(9000))
	end

	def test_third_final
		assert_equal(2532.9, calculate(15000))
	end

	def test_above_final
		assert_equal(15068.1, calculate(50000))
	end
end


